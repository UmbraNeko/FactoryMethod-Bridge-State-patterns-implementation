using System;

// Интерфейс для цветов
interface IColor
{
    void ApplyColor();
}

// Конкретная реализация интерфейса цветов
class RedColor : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Применен красный цвет.");
    }
}

// Абстрактный класс для транспорта
abstract class Transport
{
    protected IColor color;
    protected TransportState state;

    public Transport(IColor color)
    {
        this.color = color;
        state = new MovingState(this);
    }

    public void Move()
    {
        state.Move();
    }

    public void Stop()
    {
        state.Stop();
    }

    public void SetState(TransportState state)
    {
        this.state = state;
    }

    public abstract void ShowStatus();
}

// Конкретная реализация транспорта (автомобиль)
class Car : Transport
{
    public Car(IColor color) : base(color) { }

    public override void ShowStatus()
    {
        Console.WriteLine("Автомобиль");
    }
}

// Конкретная реализация транспорта (велосипед)
class Bicycle : Transport
{
    public Bicycle(IColor color) : base(color) { }

    public override void ShowStatus()
    {
        Console.WriteLine("Велосипед");
    }
}

// Абстрактный класс для состояний
abstract class TransportState
{
    protected Transport transport;

    public TransportState(Transport transport)
    {
        this.transport = transport;
    }

    public abstract void Move();
    public abstract void Stop();
}

// Конкретная реализация состояния "едет"
class MovingState : TransportState
{
    public MovingState(Transport transport) : base(transport) { }

    public override void Move()
    {
        Console.WriteLine("Транспорт движется.");
    }

    public override void Stop()
    {
        Console.WriteLine("Транспорт останавливается.");
        transport.SetState(new StoppedState(transport));
    }
}

// Конкретная реализация состояния "остановлен"
class StoppedState : TransportState
{
    public StoppedState(Transport transport) : base(transport) { }

    public override void Move()
    {
        Console.WriteLine("Транспорт начинает движение.");
        transport.SetState(new MovingState(transport));
    }

    public override void Stop()
    {
        Console.WriteLine("Транспорт уже остановлен.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем автомобиль с красным цветом
        IColor redColor = new RedColor();
        Transport car = new Car(redColor);

        // Показываем текущий статус автомобиля
        car.ShowStatus();

        // Двигаем автомобиль
        car.Move();

        // Останавливаем автомобиль
        car.Stop();

        // Пытаемся остановить уже остановленный автомобиль
        car.Stop();

        Console.WriteLine();

        // Создаем велосипед с красным цветом
        Transport bicycle = new Bicycle(redColor);

        // Показываем текущий статус велосипеда
        bicycle.ShowStatus();

        // Двигаем велосипед
        bicycle.Move();

        // Останавливаем велосипед
        bicycle.Stop();

        Console.ReadLine();
    }
}
