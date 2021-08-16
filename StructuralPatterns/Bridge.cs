using System;

public class Program {
	static void Main(string[] args) {
		// client code
		Color c1 = new Red();
		Cube cu1 = new Cube(c1, 5);

		cu1.print();

		Color c2 = new Blue();
		Sphere s1 = new Sphere(c2, 5.0);

		s1.print();
		Console.WriteLine(s1.volume());
	}
}

abstract class Shape {
	protected Color color;
	protected string shape;

	public void print() {
		this.color.print(this.shape);
	}
	public abstract double volume();
}

class Cube : Shape{
	double side;

	public Cube(Color c, double s) {
		this.color = c;
		this.shape = "cube";
		this.side = s;
	}

	public override double volume() {
		return Math.Pow(this.side, 3.0);
	}
}

class Sphere : Shape{
	double radius;

	public Sphere(Color c, double r) {
		this.color = c;
		this.shape = "sphere";
		this.radius = r;
	}

	public override double volume() {
		return (3.0 / 4.0) * Math.PI * Math.Pow(this.radius, 3.0);
	}
}

interface Color {
	void print(string shape);
}

class Red : Color {
	string color;

	public Red() {
		this.color = "red";
	}

	public void print(string shape) {
		Console.WriteLine(this.color + " " + shape);
	}
}

class Blue : Color {
	string color;

	public Blue() {
		this.color = "blue";
	}

	public void print(string shape) {
		Console.WriteLine(this.color + " " + shape);
	}
}