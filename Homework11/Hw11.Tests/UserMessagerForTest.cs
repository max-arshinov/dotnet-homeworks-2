namespace Hw11Tests;

public static class UserMessagerForTest
{
    public static string WaitingTimeIsLess(long minExpectedTime, long executionTime) =>
        $@"Время подсчета меньше ожидаемого.
           Мин время: {minExpectedTime}, актуальное время: {executionTime}";

    public static string WaitingTimeIsMore(long maxExpectedTime, long executionTime) =>
        $@"Время подсчета больше ожидаемого.
           Макс время: {maxExpectedTime}, актуальное время: {executionTime});";
}