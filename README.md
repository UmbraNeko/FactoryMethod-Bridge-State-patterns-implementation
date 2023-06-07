# Практическая работа №2
## FactoryMethod-Bridge-State-patterns-implementation
## Фабричный метод
   Factory Method - это порождающий паттерн, который предоставляет интерфейс для создания объектов, но делегирует фактическую логику создания подклассам. В данной программе фабричный метод реализуется через интерфейс ITransportFactory, который имеет метод CreateTransport(). Конкретные реализации этого интерфейса (CarFactory и BicycleFactory) отвечают за создание конкретных объектов (Car и Bicycle соответственно). Таким образом, фабричный метод позволяет гибко создавать различные типы транспорта, добавляя новые фабрики и конкретные классы транспорта без изменения кода клиента.

## Мост
   Bridge - это структурный паттерн, который разделяет абстракцию и реализацию друг от друга. В данной программе абстрактный класс Transport представляет абстракцию, а конкретные классы Car и Bicycle представляют реализации. Разделение позволяет изменять их независимо друг от друга. Например, можно добавить новый тип транспорта, создав новый класс, наследующий Transport, и новую реализацию, наследующую TransportState, без изменения существующего кода. Мост также позволяет динамически изменять реализацию во время выполнения, как это делается при изменении состояний транспорта.

## Состояние
   State - это паттерн состояния, который позволяет объекту изменять свое поведение в зависимости от его внутреннего состояния. В данной программе состояния транспорта представлены абстрактным классом TransportState и его конкретными реализациями CarParkingState и BicycleStopState. Когда состояние транспорта изменяется (например, автомобиль припаркован или велосипед остановлен), объект передает обработку входных событий соответствующему состоянию. Каждое состояние может иметь свое собственное поведение при обработке входных событий, что позволяет объекту вести себя по-разному в разных состояниях.

Вместе эти паттерны позволяют создавать и управлять различными типами транспорта, а также изменять их состояния и поведение в удобной и расширяемой манере.
# UML программы



![3](https://github.com/UmbraNeko/FactoryMethod-Bridge-State-patterns-implementation/assets/104635652/a08ec56c-b8f9-4cbc-9dbc-8443de80d8cc)
