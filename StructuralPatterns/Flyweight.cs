using System;
using System.Collections.Generic;

public class Program {
	static void Main(string[] args) {
		// client code
		Building supermarket = new Building(1, 2,
			BuildingFactory.get_building_type("market", "green", "market.png"));
		supermarket.render();
	}
}

// extrinsic class
class Building {
	int x, y;
	BuildingTypes type;

	public Building(int x, int y, BuildingTypes type) {
		this.x = x;
		this.y = y;
		this.type = type;
	}

	public void render() {
		type.render(this.x, this.y);
	}
}

// intrinsic class
class BuildingTypes {
	string type;
	string color;
	string texture_filename;

	public BuildingTypes(string t, string c, string tf) {
		this.type = t;
		this.color = c;
		this.texture_filename = tf;
	}

	public void render(int x, int y) {
		System.Console.WriteLine("A " + this.color + " " + this.type +
			"building is at " + x + ", " + y);
	}
	public string get_type() { return this.type; }
}

// flyweight factory
class BuildingFactory {
	static List<BuildingTypes> building_types = new List<BuildingTypes>();

	public static BuildingTypes get_building_type(string type, string color, string tf) {
		BuildingTypes t = building_types.Find(e => e.get_type() == type);

		if (t == null) {
			t = new BuildingTypes(type, color, tf);
			building_types.Add(t);
		}

		return t;
	}
}