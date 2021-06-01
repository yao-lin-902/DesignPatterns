using System;

public class Program {
	static void Main(string[] args) {
		// client code
		HollowBall hb = new HollowBall(5);
		Ball b = new Ball(4);

		System.Console.WriteLine("Does the ball with radius " + b.get_radius() + " fit? " + hb.fit(b));

		Cube c = new Cube(5);
		CubeBall cb = new CubeBall(c);

		System.Console.WriteLine("Does the cube with width " + c.get_width() + " fit? " + hb.fit(cb));

		Cube c2 = new Cube(8);
		CubeBall cb2 = new CubeBall(c2);

		System.Console.WriteLine("Does the cube with width " + c2.get_width() + " fit? " + hb.fit(cb2));
	}
}

// target class
class HollowBall {
	double radius;

	public HollowBall() {
		this.radius = 0;
	}

	public HollowBall(double radius) {
		this.radius = radius;
	}

	public bool fit(Ball b) {
		//System.Console.WriteLine(((CubeBall)b).get_radius() + " " + this.radius);
		return b.get_radius() <= this.radius;
	}
}


class Ball {
	double radius;

	public Ball() {
		this.radius = 0;
	}

	public Ball(double radius) {
		this.radius = radius;
	}

	public virtual double get_radius() {
		return this.radius;
	}
}

// adaptee class
class Cube {
	double width;

	public Cube() {
		this.width = 0;
	}

	public Cube(double width) {
		this.width = width;
	}

	public double get_width() {
		return this.width;
	}
}

// adapter class
class CubeBall : Ball {
	Cube cube;

	public CubeBall() {
		this.cube = new Cube();
	}

	public CubeBall(Cube c) {
		this.cube = c;
	}

	public override double get_radius() {
		return (this.cube.get_width() * Math.Sqrt(3)) / 2.0;
	}
}