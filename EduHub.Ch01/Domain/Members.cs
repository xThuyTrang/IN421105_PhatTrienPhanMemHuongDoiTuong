using System;

namespace EduHub.Ch01.Domain
{
    /// <summary>
    /// Đại diện cho một thành viên sinh viên trong hệ thống EduHub.
    /// </summary>
    public class Member
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string StudentCode { get; private set; }
        public DateTime JoinedAt { get; init; }
        public bool IsActiveStatus { get; private set; }

        private Member(Guid id, string name, string email, string studentCode, DateTime joinedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            StudentCode = studentCode;
            JoinedAt = joinedAt;
            IsActiveStatus = true;
        }

        /// <summary>
        /// Factory method khởi tạo đối tượng Member với kiểm tra dữ liệu đầu vào.
        /// </summary>
        public static Member Create(string name, string email, string studentCode)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên thành viên không được để trống.", nameof(name));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Email không hợp lệ (thiếu ký tự @).", nameof(email));
            if (string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Mã số sinh viên không được để trống.", nameof(studentCode));

            return new Member(Guid.NewGuid(), name.Trim(), email.Trim(), studentCode.Trim(), DateTime.Now);
        }

        /// <summary>
        /// Kiểm tra xem thành viên có đang hoạt động hay không.
        /// </summary>
        public bool IsActive()
        {
            return IsActiveStatus;
        }

        /// <summary>
        /// Ngừng hoạt động của thành viên (dành cho Admin).
        /// </summary>
        public void Deactivate()
        {
            IsActiveStatus = false;
        }
    }
}