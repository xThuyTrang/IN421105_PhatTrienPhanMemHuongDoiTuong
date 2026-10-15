using System;

namespace EduHub.Ch01.Domain
{
    /// <summary>
    /// Ghi nhận lịch sử điểm danh của thành viên tại sự kiện.
    /// </summary>
    public class CheckIn
    {
        public Guid Id { get; init; }
        public Guid RegistrationId { get; init; }
        public DateTime CheckedInAt { get; init; }
        public string Method { get; private set; } // Ví dụ: QR Code, Manual,...

        private CheckIn(Guid id, Guid registrationId, DateTime checkedInAt, string method)
        {
            Id = id;
            RegistrationId = registrationId;
            CheckedInAt = checkedInAt;
            Method = method;
        }

        /// <summary>
        /// Factory method ghi nhận điểm danh mới.
        /// </summary>
        public static CheckIn Create(Guid registrationId, string method = "QR Code")
        {
            if (registrationId == Guid.Empty)
                throw new ArgumentException("RegistrationId không hợp lệ.");

            return new CheckIn(Guid.NewGuid(), registrationId, DateTime.Now, string.IsNullOrWhiteSpace(method) ? "QR Code" : method.Trim());
        }

        /// <summary>
        /// Trả về chuỗi tóm tắt thông tin điểm danh.
        /// </summary>
        public string Summary()
        {
            return $"CheckIn ID: {Id} | Registration ID: {RegistrationId} | Thời gian: {CheckedInAt:yyyy-MM-dd HH:mm:ss} | Hình thức: {Method}";
        }
    }
}