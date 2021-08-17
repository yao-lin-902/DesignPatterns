using System;

public class Program {
	static void Main(string[] args) {
		// client code
		Cake cake1 = new ButterCake();
		cake1 = new ChocolateDrip(cake1);
		cake1 = new FreshFruit(cake1);
		System.Console.WriteLine(cake1.get_description() + ": $" + cake1.cost());

		Cake cake2 = new SpongeCake();
		cake2 = new WhippedCream(cake2);
		cake2 = new Candies(cake2);
		System.Console.WriteLine(cake2.get_description() + ": $" + cake2.cost());
	}
}

interface Cake {
	string get_description();
	int cost();
}

// concrete cake
class ButterCake : Cake {
	public string get_description() {
		return "butter cake";
	}

	public int cost() {
		return 45;
	}
}

class SpongeCake : Cake {
	public string get_description() {
		return "sponge cake";
	}

	public int cost() {
		return 40;
	}
}


abstract class CondimentDecorator : Cake {
	protected Cake wrappee;

	public abstract string get_description();
	public abstract int cost();
}

// condiment class
class FreshFruit : CondimentDecorator {
	public FreshFruit(Cake c) {
		this.wrappee = c;
	}

	public override string get_description() {
		return this.wrappee.get_description() + ", fresh fruit";
	}

	public override int cost() {
		return this.wrappee.cost() + 5;
	}
}

class Candies : CondimentDecorator {
	public Candies(Cake c) {
		this.wrappee = c;
	}

	public override string get_description() {
		return this.wrappee.get_description() + ", candies";
	}

	public override int cost() {
		return this.wrappee.cost() + 7;
	}
}

class ChocolateDrip : CondimentDecorator {
	public ChocolateDrip(Cake c) {
		this.wrappee = c;
	}

	public override string get_description() {
		return this.wrappee.get_description() + ", chocolate drip";
	}

	public override int cost() {
		return this.wrappee.cost() + 3;
	}
}

class WhippedCream : CondimentDecorator {
	public WhippedCream(Cake c) {
		this.wrappee = c;
	}

	public override string get_description() {
		return this.wrappee.get_description() + ", whipped cream";
	}

	public override int cost() {
		return this.wrappee.cost() + 2;
	}
}