using System;
using System.Collections.Generic;

// Abstract class representing a vehicle
abstract class PhuongTien
{
    public string TenPhuongTien { get; set; }
    public string LoaiNhienLieu { get; set; }

    public PhuongTien(string tenPhuongTien, string loaiNhienLieu)
    {
        TenPhuongTien = tenPhuongTien;
        LoaiNhienLieu = loaiNhienLieu;
    }

    // Abstract method for moving the vehicle
    public abstract void DiChuyen();
}

// Interface for additional information
interface IThongTinThem
{
    int TocDoToiDa(); // Maximum speed
    double MucTieuThuNhienLieu(); // Fuel consumption rate
}

// Car class inheriting from PhuongTien and implementing IThongTinThem
class XeHoi : PhuongTien, IThongTinThem
{
    public XeHoi(string tenPhuongTien, string loaiNhienLieu)
        : base(tenPhuongTien, loaiNhienLieu)
    {
    }

    public override void DiChuyen()
    {
        Console.WriteLine($"{TenPhuongTien} đang di chuyển bằng xăng.");
    }

    public int TocDoToiDa()
    {
        return 200; // Maximum speed in km/h
    }

    public double MucTieuThuNhienLieu()
    {
        return 8.5; // Fuel consumption in liters per 100 km
    }
}

// Bicycle class inheriting from PhuongTien
class XeDap : PhuongTien, IThongTinThem
{
    public XeDap(string tenPhuongTien)
        : base(tenPhuongTien, "Không sử dụng nhiên liệu")
    {
    }

    public override void DiChuyen()
    {
        Console.WriteLine($"{TenPhuongTien} đang di chuyển bằng sức người.");
    }

    public double MucTieuThuNhienLieu()
    {
        throw new NotImplementedException();
    }

    public int TocDoToiDa()
    {
        return 25; // Maximum speed in km/h
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<PhuongTien> danhSachPhuongTien = new List<PhuongTien>
        {
            new XeHoi("Xe hơi", "Xăng"),
            new XeDap("Xe đạp")
        };

        foreach (PhuongTien phuongTien in danhSachPhuongTien)
        {
            Console.WriteLine($"Tên phương tiện: {phuongTien.TenPhuongTien}");
            Console.WriteLine($"Loại nhiên liệu: {phuongTien.LoaiNhienLieu}");
            phuongTien.DiChuyen();

            if (phuongTien is IThongTinThem thongTinThem)
            {
                Console.WriteLine($"Tốc độ tối đa: {thongTinThem.TocDoToiDa()} km/h");

                if (phuongTien is XeHoi xeHoi)
                {
                    Console.WriteLine($"Mức tiêu thụ nhiên liệu: {xeHoi.MucTieuThuNhienLieu()} lít/100 km");
                }
            }

            Console.WriteLine();
        }
    }
}
