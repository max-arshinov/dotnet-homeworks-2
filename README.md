# Домашняя работа для третьего учебного семестра (2 год обучения)

![.NET](https://github.com/k0c0w/dotnet-homeworks-2/actions/workflows/dotnet.yml/badge.svg)
[![codecov](https://codecov.io/gh/k0c0w/dotnet-homeworks-2/branch/homework/graph/badge.svg)](https://codecov.io/gh/k0c0w/dotnet-homeworks-2)

## Как устроены Actions
1. ***build***: *Проверка: собирается ли проект.*
2. ***test*** и ***test-report***: *Все тесты должны проходить*
4. ***codecov***: *Программа должна быть на 100% покрыта тестами.* 
Тесты, которые уже были написаны заранее, проверяют работоспособность вашей программы:  верно ли выполнено задание.
Однако при реализации вы можете добавлять свои классы/сервисы и вот для них вы должны написать свои собственные тесты.
5. После этого в рамках локального репозитория создаётся пулл реквест из ветки с решённым домашним заданием в master. Далее произойдёт автоматический запуск всех workflow:
- если все workflow успешно отработают , то просите ментора провести code-review. 
- иначе смотрите логи workflow, который не отработал и исправляете проблему.
