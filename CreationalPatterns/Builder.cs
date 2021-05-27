using System;

public class Program {
	static void Main(string[] args) {
		// client code
		ElectornicsManufacture em = new ElectornicsManufacture();

		// builds phones
		CellPhoneBuilder builder = new CellPhoneBuilder();
		em.set_builder(builder);
		em.build_iphone();

		CellPhone iPhone = (CellPhone)em.get_product();
		iPhone.use_phone();

		em.build_samsung_note();

		CellPhone note = (CellPhone)em.get_product();
		note.use_phone();

		// builds laptops
		LaptopBuilder builder2 = new LaptopBuilder();
		em.set_builder(builder2);
		em.build_thinkpad();

		Laptop tp = (Laptop)em.get_product();
		tp.use_laptop();
	}
}

interface Product {}

// products to build
class CellPhone : Product {
	string brand;
	string operating_system;

	bool has_screen_protector;
	bool has_sim_card;
	float screen_resolution;

	// setter methods
	public void set_brand(string brand) { this.brand = brand; }
	public void set_os(string os) { this.operating_system = os; }
	public void set_screen_protector(bool has_screen_protector) { this.has_screen_protector = has_screen_protector; }
	public void set_sim_card(bool has_sim_card) { this.has_sim_card = has_sim_card; }
	public void set_screen_resolution(float screen_resolution) { this.screen_resolution = screen_resolution; }

	public void use_phone() {
		System.Console.WriteLine(brand + "'s phone run on " + operating_system);
	}
}

class Laptop : Product {
	string brand;
	string operating_system;

	bool has_keyboard;
	float screen_resolution;

	// setter methods
	public void set_brand(string brand) { this.brand = brand; }
	public void set_os(string os) { this.operating_system = os; }
	public void set_keyboard(bool has_keyboard) { this.has_keyboard = has_keyboard; }
	public void set_screen_resolution(float screen_resolution) { this.screen_resolution = screen_resolution; }

	public void use_laptop() {
		System.Console.WriteLine(brand + "'s laptop run on " + operating_system);
	}
}


// builder classes
interface Builder {
	void reset();
	void put_on_brand_logo(string logo);
	void setup_screen_protector(bool has_screen_protector);
	void setup_sim_card(bool has_sim_card);
	void setup_keyboard(bool has_keyboard);
	void install_os(string operating_system);
	void install_screen(float screen_size);
	Product get_product();
}

// concrete builders
class CellPhoneBuilder : Builder {
	private CellPhone cellphone;

	public CellPhoneBuilder() {
		this.reset();
	}

	public void reset() {
		this.cellphone = new CellPhone();
	}

	public Product get_product() {
		CellPhone cp = this.cellphone;
		this.reset();
		return cp;
	}

	// building functions
	public void put_on_brand_logo(string logo) {
		cellphone.set_brand(logo);
	}
	public void setup_screen_protector(bool has_screen_protector) {
		cellphone.set_screen_protector(has_screen_protector);
	}
	public void setup_sim_card(bool has_sim_card) {
		cellphone.set_sim_card(has_sim_card);
	}
	public void setup_keyboard(bool has_keyboard) {}
	public void install_os(string os) {
		cellphone.set_os(os);
	}
	public void install_screen(float screen_size) {
		cellphone.set_screen_resolution(screen_size);
	}
}

class LaptopBuilder : Builder {
	private Laptop laptop;

	public LaptopBuilder() {
		this.reset();
	}

	public void reset() {
		this.laptop = new Laptop();
	}

	public Product get_product() {
		Laptop l = this.laptop;
		this.reset();
		return l;
	}

	// buildind functions
	public void put_on_brand_logo(string logo) {
		laptop.set_brand(logo);
	}
	public void setup_screen_protector(bool has_screen_protector) {}
	public void setup_sim_card(bool has_sim_card) {}
	public void setup_keyboard(bool has_keyboard) {
		laptop.set_keyboard(has_keyboard);
	}
	public void install_os(string os) {
		laptop.set_os(os);
	}
	public void install_screen(float screen_size) {
		laptop.set_screen_resolution(screen_size);
	}
}


// director
class ElectornicsManufacture {
	private Builder builder;

	public void set_builder(Builder b) {
		this.builder = b;
	}

	public void build_iphone() {
		builder.reset();
		builder.put_on_brand_logo("Apple");
		builder.setup_screen_protector(true);
		builder.setup_sim_card(true);
		builder.install_os("iOS");
		builder.install_screen(6.1f);
	}

	public void build_samsung_note() {
		builder.reset();
		builder.put_on_brand_logo("Samsung");
		builder.setup_screen_protector(true);
		builder.setup_sim_card(true);
		builder.install_os("Andriod");
		builder.install_screen(6.4f);
	}

	public void build_thinkpad() {
		builder.reset();
		builder.put_on_brand_logo("Lenovo");
		builder.setup_keyboard(true);
		builder.install_os("Windows 10");
		builder.install_screen(14f);
	}

	public Product get_product() {
		return builder.get_product();
	}
}