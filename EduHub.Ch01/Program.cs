using System;
using System.Collections.Generic;
using System.Linq;
using EduHub.Ch01.Domain;

// Thiết lập hiển thị tiếng Việt trên Console
Console.OutputEncoding = System.Text.Encoding.UTF8;

const string Separator = "========================================";
const int EventCapacity = 50;

void Step(int number, string title) => Console.WriteLine($"\n{Separator}\nBước {number}: {title}\n{Separator}");

// Bước 1 — Tạo CLB
Step(1, "Tạo câu lạc bộ");
var club = Club.Create("Tech Club", "Câu lạc bộ công nghệ: workshop, hackathon, chia sẻ kiến thức.");
Console.WriteLine($"CLB: {club.Name} — {club.Description}");

// Bước 2 — Thêm 3 thành viên
Step(2, "Thêm thành viên");
var members = new[]
{
    Member.Create("Nguyễn Văn An", "an.nv@student.dthu.edu.vn", "DH24001"),
    Member.Create("Trần Thị Bình", "binh.tt@student.dthu.edu.vn", "DH24002"),
    Member.Create("Lê Hoàng Cường", "cuong.lh@student.dthu.edu.vn", "DH24003"),
};
foreach (var member in members)
{
    club.AddMember(member);
    Console.WriteLine($"+ {member.Name} ({member.StudentCode}) <{member.Email}>");
}
Console.WriteLine($"Tổng thành viên: {club.MemberCount()}");

// Bước 3 — Tạo sự kiện
Step(3, "Tạo sự kiện");
var workshop = Event.Create(club.Id, "Workshop AI", DateTime.Today.AddDays(7).AddHours(14), EventCapacity, true);
Console.WriteLine($"Sự kiện: {workshop.Title} — {workshop.Date:dd/MM/yyyy HH:mm} — sức chứa {workshop.Capacity}");

// Bước 4 — 2 thành viên đăng ký, rồi xác nhận
Step(4, "Đăng ký tham dự");
var registrations = new List<Registration>();
foreach (var member in members.Take(2))
{
    if (!workshop.HasCapacity(registrations.Count))
    {
        Console.WriteLine($"! Hết chỗ, không nhận {member.Name}");
        continue;
    }
    var registration = Registration.Create(member.Id, workshop.Id);
    registrations.Add(registration);
    Console.WriteLine($"{member.Name} đăng ký → {registration.Status}");
}

Step(5, "Xác nhận đăng ký");
foreach (var registration in registrations)
{
    registration.Confirm();
    Console.WriteLine($"Phiếu {registration.Id.ToString()[..8]} → {registration.Status}");
}

// Bước 6 — 1 thành viên check-in
Step(6, "Check-in");
var checkIns = new List<CheckIn> { CheckIn.Create(registrations[0].Id, "QR Code") };
Console.WriteLine(checkIns[0].Summary());

// Báo cáo tham dự
Step(7, "Báo cáo tham dự");
Console.WriteLine($"Số đăng ký: {registrations.Count}/{workshop.Capacity}");
Console.WriteLine($"Số check-in: {checkIns.Count}");
var memberById = members.ToDictionary(m => m.Id);
foreach (var registration in registrations)
{
    var attended = checkIns.Any(c => c.RegistrationId == registration.Id);
    Console.WriteLine($"{memberById[registration.MemberId].Name}: {(attended ? "đã check-in" : "chưa check-in")}");
}

// Minh hoạ bất biến: Cancelled là trạng thái cuối
Step(8, "Kiểm tra quy tắc nghiệp vụ");
registrations[1].Cancel();
try
{
    registrations[1].Confirm();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Đúng như mong đợi: {ex.Message}");
}

Console.WriteLine($"\n{Separator}\nChương trình demo hoàn tất!\n{Separator}");