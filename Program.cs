using System;
using System.Collections.Generic;

// Интерфейс для фабричного метода
interface ITransportFactory
{
    ITransport CreateTransport();
}

// Абстрактный класс для транспорта
abstract class Transport
{
    protected ITransportFactory factory;

    public Transport(ITransportFactory factory)
    {
        this.factory = factory;
    }

    public abstract void Move();
}

// Абстрактный класс для состояний
abstract class TransportState
{
    protected Transport transport;

    public TransportState(Transport transport)
    {
        this.transport = transport;
    }

    public abstract void HandleInput();
}

// Конкретная реализация фабричного метода для создания автомобилей
class CarFactory : ITransportFactory
{
    public ITransport CreateTransport()
    {
        return new Car();
    }
}

// Конкретная реализация фабричного метода для создания велосипедов
class BicycleFactory : ITransportFactory
{
    public ITransport CreateTransport()
    {
        return new Bicycle();
    }
}

// Конкретная реализация транспорта (автомобиль)
class Car : Transport
{
    public Car() : base(new CarFactory()) { }

    public override void Move()
    {
        Console.WriteLine("Автомобиль едет по дороге.");
    }
}

// Конкретная реализация транспорта (велосипед)
class Bicycle : Transport
{
    public Bicycle() : base(new BicycleFactory()) { }

    public override void Move()
    {
        Console.WriteLine("Велосипед движется по тротуару.");
    }
}

// Конкретная реализация состояния для автомобиля (парковка)
class CarParkingState : TransportState
{
    public CarParkingState(Transport transport) : base(transport) { }

    public override void HandleInput()
    {
        Console.WriteLine("Автомобиль припаркован.");
        transport.Move(); // После парковки автомобиль может снова двигаться
    }
}

// Конкретная реализация состояния для велосипеда (остановка)
class BicycleStopState : TransportState
{
    public BicycleStopState(Transport transport) : base(transport) { }

    public override void HandleInput()
    {
        Console.WriteLine("Велосипед остановлен.");
        transport.Move(); // После остановки велосипед может снова двигаться
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем автомобиль и перемещаем его
        Transport car = new Car();
        car.Move();

        // Изменяем состояние автомобиля на парковку и перемещаем его
        TransportState carState = new CarParkingState(car);
        carState.HandleInput();

        // Создаем велосипед и перемещаем его
        Transport bicycle = new Bicycle();
        bicycle.Move();

        // Изменяем состояние велосипеда на остановку и перемещаем его
        TransportState bicycleState = new BicycleStopState(bicycle);
        bicycleState.HandleInput();

        Console.ReadLine();
    }
}
