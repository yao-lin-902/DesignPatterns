using System;
using System.Collections.Generic;
using System.Threading;

public class Singleton {
	static void Main(string[] args) {
		Database d1 = Database.get_instance();
		Database d2 = Database.get_instance();
		if (d1 == d2)
			System.Console.WriteLine("Singleton worked!");

		// insert albertary value
		d1.insert_data(10);
		d1.insert_data(15);
		d1.insert_data(24);
		d1.insert_data(2);

		System.Console.WriteLine(d2.get_data(1));

	}
}

// only one database should exist
public class Database {
	private List<int> data_ = new List<int>();
	private static Database instance_;

	private Database() { }

	// lazy/naive singleton
	// public static Database get_instance() {
	// 	if (instance_ == null) {
	// 		instance_ = new Database();
	// 	}
	// 	return instance_;
	// }

	// thread-safe singleton
	private static readonly object lock_ = new object();
	public static Database get_instance() {
		if (instance_ == null) {
			lock(lock_) { // lock other threads
				if (instance_ == null) { // double check
					instance_ = new Database();
				}
			}
		}
		return instance_;
	}

	public void insert_data(int data) {
		data_.Add(data);
	}

	public int get_data(int index) {
		return data_[index];
	}
}