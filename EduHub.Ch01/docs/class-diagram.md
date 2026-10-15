# Class Diagram

```mermaid
classDiagram
    class Member {
        +Guid Id (PK)
        +string Name
        +string Email
        +string StudentCode
        +DateTime JoinedAt
        +bool IsActive()
    }

    class Club {
        +Guid Id (PK)
        +string Name
        +string Description
        +DateTime CreatedAt
        +List<Member> Members
        +void AddMember(Member member)
        +int MemberCount()
    }

    class Event {
        +Guid Id (PK)
        +Guid ClubId (FK)
        +string Title
        +DateTime Date
        +int Capacity
        +bool IsOnline
        +bool HasCapacity(int registeredCount)
    }

    class Registration {
        +Guid Id (PK)
        +Guid MemberId (FK)
        +Guid EventId (FK)
        +DateTime RegisteredAt
        +string Status
        +void Confirm()
        +void Cancel()
    }

    class CheckIn {
        +Guid Id (PK)
        +Guid RegistrationId (FK)
        +DateTime CheckedInAt
        +string Summary()
    }

    %% Quan hệ giữa các lớp và bội số
    Club "1" --> "*" Event : tổ chức
    Club "*" --> "*" Member : bao gồm
    Member "1" --> "*" Registration : tạo
    Event "1" --> "*" Registration : nhận
    Registration "1" --> "0..1" CheckIn : điểm danh