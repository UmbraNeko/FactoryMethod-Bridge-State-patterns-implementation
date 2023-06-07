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

    // Абстрактный фабричный метод
    public abstract Transport CreateTransport();
}

// Конкретная фабрика для создания автомобиля
class CarFactory : Transport
{
    public CarFactory(IColor color) : base(color) { }

    public override void ShowStatus()
    {
        Console.WriteLine("Автомобиль");
    }

    // Переопределенный фабричный метод
    public override Transport CreateTransport()
    {
        return new Car(color);
    }
}

// Конкретная фабрика для создания велосипеда
class BicycleFactory : Transport
{
    public BicycleFactory(IColor color) : base(color) { }

    public override void ShowStatus()
    {
        Console.WriteLine("Велосипед");
    }

    // Переопределенный фабричный метод
    public override Transport CreateTransport()
    {
        return new Bicycle(color);
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
        // Создаем фабрику для автомобиля с красным цветом
        IColor redColor = new RedColor();
        TransportFactory carFactory = new CarFactory(redColor);

        // Используем фабрику для создания автомобиля
        Transport car = carFactory.CreateTransport();

        // Показываем текущий статус автомобиля
        car.ShowStatus();

        // Двигаем автомобиль
        car.Move();

        // Останавливаем автомобиль
        car.Stop();

        // Пытаемся остановить уже остановленный автомобиль
        car.Stop();

        Console.WriteLine();

        // Создаем фабрику для велосипеда с красным цветом
        TransportFactory bicycleFactory = new BicycleFactory(redColor);

        // Используем фабрику для создания велосипеда
        Transport bicycle = bicycleFactory.CreateTransport();

        // Показываем текущий статус велосипеда
        bicycle.ShowStatus();

        // Двигаем велосипед
        bicycle.Move();

        // Останавливаем велосипед
        bicycle.Stop();

        Console.ReadLine();
    }
}
