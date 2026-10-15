using System;
using System.Collections.Generic;

namespace EduHub.Ch01.Domain
{
    /// <summary>
    /// Đại diện cho Câu lạc bộ sinh viên.
    /// </summary>
    public class Club
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; init; }

        private readonly List<Member> _members = new();
        public IReadOnlyCollection<Member> Members => _members.AsReadOnly();

        private Club(Guid id, string name, string description, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Factory method khởi tạo Club với validation.
        /// </summary>
        public static Club Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên câu lạc bộ không được để trống.", nameof(name));

            return new Club(Guid.NewGuid(), name.Trim(), description?.Trim() ?? string.Empty, DateTime.Now);
        }

        /// <summary>
        /// Thêm thành viên vào câu lạc bộ (kiểm tra không cho trùng lặp).
        /// </summary>
        public void AddMember(Member member)
        {
            ArgumentNullException.ThrowIfNull(member);
            if (_members.Exists(m => m.Id == member.Id))
                throw new InvalidOperationException("Thành viên này đã tham gia câu lạc bộ từ trước.");

            _members.Add(member);
        }

        /// <summary>
        /// Trả về tổng số lượng thành viên hiện tại trong câu lạc bộ.
        /// </summary>
        public int MemberCount()
        {
            return _members.Count;
        }
    }
}