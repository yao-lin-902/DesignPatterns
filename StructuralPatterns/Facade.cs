using System;
using System.Collections.Generic;

public class Program {
	static void Main(string[] args) {
		// client code
		ComputerFacade cf = new ComputerFacade();
		Computer home_pc = cf.build();

		// testing the pc
		cf.turn_on(home_pc);
	}
}

// library / class
interface Component {
	void verify();
}

interface ElectronicComponent : Component {
	void power_on();
}

class CPU : ElectronicComponent {
	string model;

	public CPU(string model) {
		this.model = model;
	}

	public void verify() {
		System.Console.WriteLine("CPU exist");
	}
	public void power_on() {
		System.Console.WriteLine("CPU is powered");
	}
}

class GPU : ElectronicComponent {
	string model;

	public GPU(string model) {
		this.model = model;
	}

	public void verify() {
		System.Console.WriteLine("GPU exist");
	}
	public void power_on() {
		System.Console.WriteLine("GPU is powered");
	}
}

class Fans : ElectronicComponent {
	int rpm;

	public Fans(int rpm) {
		this.rpm = rpm;
	}

	public void verify() {
		System.Console.WriteLine("Fans exist");
	}
	public void power_on() {
		System.Console.WriteLine("Fans are powered");
	}
}

class HDD : ElectronicComponent {
	string storage_space;

	public HDD(string storage) {
		this.storage_space = storage;
	}

	public void verify() {
		System.Console.WriteLine("HDD exist");
	}
	public void power_on() {
		System.Console.WriteLine("HDD is powered");
	}
}

class ComputerCase : Component {
	string case_name;

	public ComputerCase(string name) {
		this.case_name = name;
	}

	public void verify() {
		System.Console.WriteLine("Case exist");
	}
}

class Computer {
	public List<Component> component;

	public Computer() {
		this.component = new List<Component>();
	}
}


// facade class
class ComputerFacade {
	public Computer build() {
		Computer pc = new Computer();

		ComputerCase pc_case = new ComputerCase("NZXT");
		HDD hard_drive = new HDD("1TB");
		Fans silent_fan = new Fans(1000);
		CPU cpu = new CPU("Intel Pentium");
		GPU graphics_card = new GPU("GT1030");

		pc.component.Add(pc_case);
		pc.component.Add(hard_drive);
		pc.component.Add(silent_fan);
		pc.component.Add(cpu);
		pc.component.Add(graphics_card);

		return pc;
	}

	public void turn_on(Computer pc) {
		foreach (Component c in pc.component) {
			c.verify();
		}
		foreach (Component c in pc.component) {
			var c_temp = c as ElectronicComponent;
			if (c_temp != null) {
				c_temp.power_on();
			}
		}
	}
}