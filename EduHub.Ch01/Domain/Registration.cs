using System;

namespace EduHub.Ch01.Domain
{
    /// <summary>
    /// Quản lý trạng thái đăng ký tham gia sự kiện của thành viên.
    /// </summary>
    public class Registration
    {
        public Guid Id { get; init; }
        public Guid MemberId { get; init; }
        public Guid EventId { get; init; }
        public DateTime RegisteredAt { get; init; }
        public string Status { get; private set; } // Pending, Confirmed, Cancelled

        private Registration(Guid id, Guid memberId, Guid eventId, DateTime registeredAt, string status)
        {
            Id = id;
            MemberId = memberId;
            EventId = eventId;
            RegisteredAt = registeredAt;
            Status = status;
        }

        /// <summary>
        /// Factory method tạo phiếu đăng ký mới (mặc định trạng thái là Pending).
        /// </summary>
        public static Registration Create(Guid memberId, Guid eventId)
        {
            if (memberId == Guid.Empty || eventId == Guid.Empty)
                throw new ArgumentException("MemberId hoặc EventId không hợp lệ.");

            return new Registration(Guid.NewGuid(), memberId, eventId, DateTime.Now, "Pending");
        }

        /// <summary>
        /// Xác nhận phiếu đăng ký.
        /// </summary>
        public void Confirm()
        {
            if (Status == "Cancelled")
                throw new InvalidOperationException("Không thể xác nhận phiếu đăng ký đã bị huỷ.");
            Status = "Confirmed";
        }

        /// <summary>
        /// Huỷ phiếu đăng ký.
        /// </summary>
        public void Cancel()
        {
            Status = "Cancelled";
        }
    }
}