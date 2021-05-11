using System;

public class Program {
	static void Main(string[] args) {
		// client code
		Circle c1 = (Circle)make_shape(new CircleCreator());

		c1.draw();
		System.Console.WriteLine("Circle's area = {0}", c1.area());

		Square s1 = (Square)make_shape(new SquareCreator());

		s1.draw();
		System.Console.WriteLine("Square's area = {0}", s1.area());
	}

	static Shape make_shape(ShapeCreator sc) {
		return sc.create_shape();
	}
}

// objects to be created
interface Shape {
	void draw();
	int area();
}

// concrete objects
class Square : Shape {
	int side;

	public Square(int side) {
		this.side = side;
	}

	public void draw() {
		System.Console.WriteLine("This is a square □.");
	}

	public int area() {
		return side * side;
	}
}

class Circle : Shape {
	int radius;

	public Circle(int radius) {
		this.radius = radius;
	}

	public void draw() {
		System.Console.WriteLine("This is a circle ◯.");
	}

	public int area() {
		return (int)(radius * radius * 3.14);
	}
}

// main factory class
abstract class ShapeCreator {
	public abstract Shape create_shape();
	public void draw_shape(Shape s) {
		s.draw();
	}
}

// concrete factories
class SquareCreator : ShapeCreator {
	public override Shape create_shape() {
		return new Square(5);
	}
}

class CircleCreator : ShapeCreator {
	public override Shape create_shape() {
		return new Circle(5);
	}
}