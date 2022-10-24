module Hw6.Client.HttpAction

open System
open System.Globalization
open System.Net
open System.Net.Http
open System.Threading.Tasks

type CalculateRequest =
    { value1: decimal
      operator: string
      value2: decimal }

type ErrorInfo =
    { code: int
      message: string }
    override this.ToString() =
        $"Error: %d{int this.code} %s{this.message}"

type ApiResponse<'a> = Result<'a, ErrorInfo>

type CalculatorApi(baseUrl: string) =
    let _httpClient = new HttpClient()

    member this.Calculate data : Task<ApiResponse<string>> =
        task {
            try
                let val1 = data.value1.ToString(CultureInfo.InvariantCulture)
                let val2 = data.value2.ToString(CultureInfo.InvariantCulture)
                
                let! result =
                    _httpClient.GetAsync(
                        $"{baseUrl}/calculate?value1={val1}&operation={data.operator}&value2={val2}"
                    )

                let! content = result.Content.ReadAsStringAsync()

                match result.StatusCode with
                | HttpStatusCode.OK -> return Ok content
                | _ ->
                    return
                        Error
                            { code = int result.StatusCode
                              message = content }
            with
            | ex -> return Error { code = -1; message = ex.Message }
        }

    interface IDisposable with
        member __.Dispose() = _httpClient.Dispose()
