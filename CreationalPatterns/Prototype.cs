using System;

public class Program {
	static void Main(string[] args) {
		// client code
		Rectangle r = new Rectangle(10, 5, "blue");
		r.clone().perimeter();
		Triangle t = new Triangle(5, 7, "red");
		t.clone().perimeter();
	}
}

// prototype class
abstract class Shape {
	string color;

	public Shape() { }

	public Shape(string color) {
		this.color = color;
	}

	// copy constructor
	public Shape(Shape s) {
		this.color = s.color;
	}

	public abstract Shape clone();
	public abstract void perimeter();
}

class Rectangle : Shape {
	int height;
	int width;

	public Rectangle(int height, int width, string color) : base(color) {
		this.height = height;
		this.width = width;
	}

	// copy constructor
	Rectangle(Rectangle r) : base(r) {
		this.height = r.height;
		this.width = r.width;
	}

	public override Shape clone() {
		return new Rectangle(this);
	}
	public override void perimeter() {
		System.Console.WriteLine("The perimeter is " + 2 * (height + width));
	}
}

class Triangle : Shape {
	int height;
	int base_;

	public Triangle(int height, int base_, string color) : base(color) {
		this.height = height;
		this.base_ = base_;
	}

	// copy constructor
	Triangle(Triangle r) : base(r) {
		this.height = r.height;
		this.base_ = r.base_;
	}

	public override Shape clone() {
		return new Triangle(this);
	}
	public override void perimeter() {
		System.Console.WriteLine("The perimetere cannot be determined");
	}
}