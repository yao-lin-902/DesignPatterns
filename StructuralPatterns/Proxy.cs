using System;

public class Program {
	static void Main(string[] args) {
		// client code
		House h1 = new ProxyHouse("red_house.jpg", 1);

		h1.get_location();
		h1.render_texture();
	}
}

interface House {
	void get_location();
	void render_texture();
}

class RealHouse : House {
	string texture_file;
	int location;

	public RealHouse(string tf, int loc) {
		this.texture_file = tf;
		this.location = loc;
	}

	public void get_location() {
		System.Console.WriteLine("This house is at " + this.location);
	}
	public void render_texture() {
		System.Console.WriteLine("Reading " + this.texture_file + "...");
	}
}

// proxy class
class ProxyHouse : House {
	RealHouse house;
	string texture_file;
	int location;

	public ProxyHouse(string tf, int loc) {
		this.texture_file = tf;
		this.location = loc;
	}

	public void get_location() {
		// lazy initilization
		if (this.house == null) {
			this.house = new RealHouse(this.texture_file, this.location);
		}
		this.house.get_location();
	}
	public void render_texture() {
		if (this.house == null) {
			this.house = new RealHouse(this.texture_file, this.location);
		}
		this.house.render_texture();
	}
}