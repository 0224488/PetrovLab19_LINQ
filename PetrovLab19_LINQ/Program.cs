using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetrovLab19_LINQ
{
	class Program
	{
		// Модель компьютера характеризуется кодом и названием марки компьютера, типом  процессора, 
		// частотой работы процессора, объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, 
		// стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
		// Создать список, содержащий 6-10 записей с различным набором значений характеристик.
		// Определить:
		// - все компьютеры с указанным процессором. Название процессора запросить у пользователя;
		// - все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
		// - вывести весь список, отсортированный по увеличению стоимости;
		// - вывести весь список, сгруппированный по типу процессора;
		// - найти самый дорогой и самый бюджетный компьютер;
		// - есть ли хотя бы один компьютер в количестве не менее 30 штук?

		static void Main(string[] args)
		{
			var models = new List<Model>();
			
			#region инициализация списка
			models.Add(new Model()
			{
				ComputerBrand = "ASUS",
				ComputerCode = 1000,
				ProcessorType = "Intel",
				ProcessorFrequency = 3.4,
				RAM = 16,
				HDD = 1,
				VideoMemory = 4,
				Price = 150,
				Count = 5
			});
			models.Add(new Model()
			{
				ComputerBrand = "HP",
				ComputerCode = 1001,
				ProcessorType = "AMD",
				ProcessorFrequency = 1.8,
				RAM = 8,
				HDD = 2,
				VideoMemory = 2,
				Price = 100,
				Count = 30
			});
			models.Add(new Model()
			{
				ComputerBrand = "Lenovo",
				ComputerCode = 1002,
				ProcessorType = "Intel",
				ProcessorFrequency = 4.4,
				RAM = 16,
				HDD = 4,
				VideoMemory = 16,
				Price = 210,
				Count = 14
			});
			models.Add(new Model()
			{
				ComputerBrand = "Acer",
				ComputerCode = 1003,
				ProcessorType = "Intel",
				ProcessorFrequency = 3.8,
				RAM = 12,
				HDD = 2,
				VideoMemory = 8,
				Price = 170,
				Count = 23
			});
			models.Add(new Model()
			{
				ComputerBrand = "HP",
				ComputerCode = 1004,
				ProcessorType = "AMD",
				ProcessorFrequency = 1.2,
				RAM = 8,
				HDD = 1,
				VideoMemory = 1,
				Price = 90,
				Count = 46
			});
			models.Add(new Model()
			{
				ComputerBrand = "Lenovo",
				ComputerCode = 1005,
				ProcessorType = "Intel",
				ProcessorFrequency = 3.0,
				RAM = 16,
				HDD = 2,
				VideoMemory = 8,
				Price = 160,
				Count = 10
			});
			#endregion

			Console.WriteLine("Введите название процессора (Intel, AMD): ");
			var procType = Console.ReadLine();
			// все компьютеры с указанным процессором
			var specialProcTypeComputers = models.Where(m => m.ProcessorType.Equals(procType, StringComparison.InvariantCultureIgnoreCase));
			Console.WriteLine($"Все компьютеры с процессором {procType}: ");
			foreach(var model in specialProcTypeComputers)
				Console.WriteLine(model);

			Console.WriteLine("\r\nВведите объем ОЗУ в ГБ: ");
			// все компьютеры с объемом ОЗУ не ниже, чем указано
			var ram = int.Parse(Console.ReadLine());
			var ramComputers = models.Where(m => m.RAM >= ram);
			Console.WriteLine($"Все компьютеры с с объемом ОЗУ не ниже {ram}ГБ: ");
			foreach(var model in ramComputers)
				Console.WriteLine(model);

			// список, отсортированный по увеличению стоимости
			var sortedList = models.OrderBy(m => m.Price);
			Console.WriteLine("\r\nCписок, отсортированный по увеличению стоимости");
			foreach(var model in sortedList)
				Console.WriteLine(model);

			// список, сгруппированный по типу процессора
			var groupedList = models.GroupBy(m => m.ProcessorType);
			Console.WriteLine("\r\nCписок, сгруппированный по типу процессора");
			foreach(var group in groupedList)
			{
				Console.WriteLine(group.Key);
				foreach(var model in group)
					Console.WriteLine($"    {model}");
			}

			// cамый дорогой компьютер
			var maxPrice = models.Max(p => p.Price);
			var mostExpensive = models.Where(m => m.Price == maxPrice).FirstOrDefault();
			Console.WriteLine($"\r\nCамый дорогой компьютер:\r\n {mostExpensive}");

			// cамый дешевый компьютер
			var minPrice = models.Min(p => p.Price);
			var mostCheapest = models.Where(m => m.Price == minPrice).FirstOrDefault();
			Console.WriteLine($"\r\nCамый дешевый компьютер:\r\n {mostCheapest}");

			Console.ReadKey();
		}

		// Модель компьютера
		public class Model
		{
			// код компьютера
			public int ComputerCode { get; set; }

			// марка компьютера
			public string ComputerBrand { get; set; }

			// тип процессора
			public string ProcessorType { get; set; }

			// частота работы процессора (ГГц)
			public double ProcessorFrequency { get; set; }

			// объем оперативной памяти (ГБ)
			public int RAM { get; set; }

			// объем жесткого диска (ТБ)
			public int HDD { get; set; }

			// объем памяти видеокарты (ГБ)
			public int VideoMemory { get; set; }

			// стоимость компьютера (у.е.)
			public int Price { get; set; }

			//  количество экземпляров, имеющихся в наличии
			public int Count { get; set; }

			public override string ToString()
			{
				return $"Код компьютера: {ComputerCode}, Марка: {ComputerBrand}, Тип процессора: {ProcessorType}, "+
					$"Частота процессора: {ProcessorFrequency} ГГц, Объем ОЗУ: {RAM} ГБ, Объем HDD: {HDD} Тб, "+
					$"Объем видео: {VideoMemory} ГБ, Цена: {Price}, Количество: {Count}";
			}
		}
	}
}
