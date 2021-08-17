using System;
using System.Collections.Generic;

public class Program {
	static void Main(string[] args) {
		// client code
		Electronics iPhone = new CellPhone();
		Food cake = new Cake();

		// put in a box
		Box package = new Box();
		package.add_item(iPhone);
		package.add_item(cake);

		System.Console.WriteLine("Box has " + package.get_product_name());
		System.Console.WriteLine("Total cost: " + package.price());
	}
}

interface Product {
	int price();
	string get_product_name();
}

abstract class Electronics : Product {
	protected string name;
	protected int battery;

	public void battery_left() {
		System.Console.WriteLine("Battery: " + this.battery + "%");
	}
	public string get_product_name() {
		return this.name;
	}

	public abstract void use();
	public abstract int price();
}

abstract class Food : Product {
	protected string name;
	protected int calorie;

	public int get_calorie() {
		return this.calorie;
	}
	public string get_product_name() {
		return this.name;
	}

	public abstract int price();
}


class CellPhone : Electronics {
	public CellPhone() {
		this.name = "cellphone";
		this.battery = 100;
	}

	public override int price() {
		return 250;
	}

	public override void use() {
		if (this.battery > 0) {
			this.battery = this.battery - 10;
		} else {
			System.Console.WriteLine("battery is dead");
		}
	}
}

class Cake : Food {
	public Cake() {
		this.name = "cake";
		this.calorie = 120;
	}

	public override int price() {
		return 50;
	}
}

class Box : Product {
	List<Product> items;

	public Box() {
		items = new List<Product>();
	}

	public void add_item(Product p) {
		items.Add(p);
	}

	public void remove_item(Product p) {
		items.Remove(p);
	}

	public int price() {
		int total_price = 0;

		foreach (Product p in items) {
			total_price += p.price();
		}

		return total_price + 2; // box cost 2
	}

	public string get_product_name() {
		string product_name = "";

		foreach (Product p in items) {
			product_name += p.get_product_name() + " ";
		}

		return product_name;
	}
}