namespace Hw6.Message

type Message =
    | SuccessfulExecution = 0
    | WrongArgLength = 1
    | WrongArgFormat = 2
    | WrongArgFormatOperation = 3
    | DivideByZero = 4