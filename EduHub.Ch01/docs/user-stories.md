# User Stories

## USER STORY – SINH VIÊN :

### US-01 : Sinh viên tham gia Club.
Là sinh viên, tôi muốn tham gia một Club, để có thể học tập từ môi trường mới.
- Given thành viên mới, When điền form và thỏa điều kiện, Then có tên trong `club.Members`.
- Given thành viên mới, When điền form và không thỏa điều kiện, Then bị từ chối.
- Given thành viên cũ, When điền form, Then bị từ chối (không trùng).

### US-02 : Đăng ký một sự kiện.
Là sinh viên, tôi muốn đăng ký một sự kiện, để giữ chỗ tham dự.
- Given còn chỗ, When đăng ký, Then tạo `Registration` ở trạng thái Pending.
- Given hết chỗ (đủ `Capacity`), When đăng ký, Then báo hết chỗ.

### US-03 : Check-in tại sự kiện.
Là sinh viên, tôi muốn check-in khi đến sự kiện, để được ghi nhận có mặt.
- Given phiếu Confirmed, When check-in, Then tạo `CheckIn`.
- Given phiếu Pending hoặc Cancelled, When check-in, Then bị từ chối.

## USER STORY – CLUB :

### US-04 : Tạo sự kiện
Là Ban CLB, tôi muốn tạo sự kiện, để thu hút thành viên tham gia.
- Given `Capacity > 0` và có tiêu đề, When tạo, Then sự kiện gắn đúng `clubId`.
- Given tiêu đề trống hoặc `Capacity <= 0`, When tạo, Then báo lỗi.

### US-05 : Xem báo cáo tham dự
Là Ban CLB, tôi muốn xem báo cáo tham dự, để đánh giá hiệu quả sự kiện.
- Thấy số người đăng ký trên sức chứa và số người đã check-in.
- Liệt kê từng người đã hoặc chưa check-in.

## USER STORY – ADMIN :

### US-06 : Ngừng một thành viên
Là Admin, tôi muốn ngừng hoạt động một thành viên, để giữ danh sách CLB chính xác.
- Given thành viên đang Active, When ngừng, Then `IsActive()` trả về false.
- Lịch sử đăng ký của người đó vẫn được giữ.