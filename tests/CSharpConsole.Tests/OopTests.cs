using Xunit;

namespace CSharpConsole.Tests;

public class OopTests
{
    
    private record Dog(string Name, string Breed, int Height,
        float Weight, int Age);

    [Fact]
    public void TestRecord()
    {
        Dog doggy = new("Rex", "German Shepherd", 60, 30.5f, 3);
        Console.Out.WriteLine($"Doggy: {doggy}");
        
        Assert.Equal("Rex", doggy.Name);
        Assert.Equal("German Shepherd", doggy.Breed);
        
        Dog beauty = doggy with { Name = "Beauty" };
        Assert.Equal("Beauty", beauty.Name);
        
        var (name, _, _, _, age) = doggy;
        Assert.Equal("Rex", name);
        Assert.Equal(3, age);
    }

    public interface IDevice
    {
        string Model { get; init; }
        string Number { get; init; }
        int Year { get; set; }
        void Configure(string configuration);
        bool Start();
        bool Stop();
    }
    
    class Device(string model, string number) : IDevice
    {
        public string Model { get; init; } = model;
        public string Number { get; init; } = number;
        public int Year { get; set; }
        public void Configure(string configuration) => Console.WriteLine($"Configuring {Model}...");
        public bool Start() => true;
        public bool Stop() => false;
    }
    
    [Fact]
    public void TestInterface()
    {
        IDevice device = new Device("X100", "123") { Year = 2021 };
        device.Configure("default");
        Assert.True(device.Start());
        Assert.False(device.Stop());
    }

    
    delegate double Mean(double a, double b, double c);
    
    [Fact]
    public void TestDelegation()
    {
        Mean arithmetic = (a, b, c) => a + b + c / 3;
        Mean geometric = delegate(double a, double b, double c)
        {
            return Math.Pow(a * b * c, 1D / 3);
        };
        Mean harmonic = Harmonic;
        double Harmonic (double a, double b, double c) => 
            3 / (1 / a + 1 / b + 1 / c); 
    }
}