using System;

public class Program {
	static void Main(string[] args) {
		// client code
		make_shape(new SquareFactory());
		make_shape(new CircleFactory());
	}

	static void make_shape(ShapeFactory factory) {
		FilledShape fs = factory.create_filled_shape();
		EmptyShape es = factory.create_empty_shape();

		fs.draw_and_fill();
		es.outline();
	}
}

// object abstract classes
interface FilledShape {
	void draw_and_fill();
}

interface EmptyShape {
	void outline();
}

// concrete object classes
class FilledSquare : FilledShape {
	public void draw_and_fill() {
		System.Console.WriteLine("This is a filled square ■.");
	}
}

class EmptySquare : EmptyShape {
	public void outline() {
		System.Console.WriteLine("This is an empty square □.");
	}
}


class FilledCircle : FilledShape {
	public void draw_and_fill() {
		System.Console.WriteLine("This is a filled circle ⬤.");
	}
}

class EmptyCircle : EmptyShape {
	public void outline() {
		System.Console.WriteLine("This is an empty circle ◯.");
	}
}


// factories
interface ShapeFactory {
	FilledShape create_filled_shape();
	EmptyShape create_empty_shape();
}

class SquareFactory : ShapeFactory {
	public FilledShape create_filled_shape() {
		return new FilledSquare();
	}

	public EmptyShape create_empty_shape() {
		return new EmptySquare();
	}
}

class CircleFactory : ShapeFactory {
	public FilledShape create_filled_shape() {
		return new FilledCircle();
	}

	public EmptyShape create_empty_shape() {
		return new EmptyCircle();
	}
}