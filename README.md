# :department_store: Cửa hàng bán sách trực tuyến BHT Bookstore :books:

# :pushpin: Mô tả đề tài.
- Sách được bán tại cửa hàng, sách bao gồm các thông tin: Mã ISBN, tên sách, mô tả, năm xuất bản, trọng lượng, kích thước, số trang, giá bán. Sách có thể có một hoặc nhiều hình ảnh.
- Mỗi loại sách sẽ có một ngôn ngữ, ngôn ngữ gồm các thông tin: Mã ngôn ngữ và tên ngôn ngữ.
- Mỗi loại sách sẽ có một thể loại, thể loại gồm các thông tin: Mã thể loại và tên thể loại.
- Mỗi loại sách sẽ có một hoặc nhiều tác giả, tác giả gồm các thông tin: Mã tác giả, tên tác giả và thông tin liên hệ.
- Mỗi loại sách sẽ có nhà xuất bản, nhà xuất bản gồm các thông tin: Mã nhà xuất bản, tên nhà xuất bản, số điện thoại, địa chỉ và số fax.
- Mỗi loại sách sẽ có nhà cung cấp, nhà cung cấp gồm các thông tin: Mã nhà cung cấp, tên nhà cung cấp, số điện thoại, địa chỉ và số fax. Mỗi khi nhập hàng từ nhà cung cấp sẽ phát sinh phiếu nhập, phiếu nhập bao gồm các thông tin: Số lượng, giá nhập và ngày nhập.
- Người truy cập vào hệ thống sẽ được gọi là thành viên, mỗi thành viên sẽ có các thông tin cơ bản: Tên đăng nhập, mật khẩu, họ tên, số điện thoại, email, ảnh đại diện và mã quyền truy cập. Với mỗi thành viên chỉ có duy nhất một quyền, mỗi quyền gồm các thông tin: Mã quyền truy cập và tên quyền truy cập.
- Đối với thành viên là khách hàng, thì có thể thêm sách vào giỏ hàng, với mỗi loại sách trong giỏ hàng sẽ có các thông tin: Mã ISBN, tên sách, giá, số lượng và ngày mua. 
- Khi khách hàng lựa chọn xong tất cả sách cần mua, thì có thể tạo đơn hàng. Mỗi đơn hàng được tạo gồm các thông tin: Mã đơn hàng, ngày đặt hàng, tổng tiền, trạng thái đơn hàng (đã giao, chưa giao) và thông tin chi tiết của sách có trong đơn hàng. Với mỗi đơn hàng chỉ có thể áp dụng tối đa một khuyến mãi. Mỗi khuyến mãi gồm các thông tin: mã khuyến mãi, tên khuyến mãi, số tiền khuyến mãi, thời gian áp dụng.
- Khách hàng có thể đánh giá hoặc bình luận cho sản phẩm. Đánh giá gồm các thông tin: Số sao, ngày đánh giá. Bình luận gồm các thông tin: Mã bình luận, nội dung bình luận, ngày bình luận.

## :pushpin: Ngôn ngữ lập trình
- ASP.NET
- SQL

## :pushpin: Tính năng

### :bar_chart: Quản trị viên
- Bảng điều khiển: Thống kế theo số lượng thể loại, tác giả, nhà xuất bản, nhà cung cấp, sách, đơn hàng, tài khoản và slider.
- Thể loại: Thêm, xóa, sửa và tìm kiếm (mã, tên). Thống kê theo số lượng thể loại, thể loại gốc, thể loại con, thể loại đang hiển thị.
- Tác giả: Thêm, xóa, sửa và tìm kiếm (mã, tên). Thống kê theo số lượng tác giả.
- Nhà xuất bản: Thêm, xóa, sửa và tìm kiếm (mã, tên). Thống kê theo số lượng nhà xuất bản.
- Sách: Thêm, xóa, sửa và tìm kiếm (mã, tên). Thống kê theo số lượng sách. Xem thông tin chi tiết sản phẩm.
- Nhà cung cấp: Thêm, xóa, sửa và tìm kiếm (mã, tên). Thống kê theo số lượng nhà cung cấp.
- Đơn hàng: Tìm kiếm (mã). Thống kê theo số lượng đơn hàng, đơn hàng đã giao, đơn hàng chưa giao, doanh thu tháng hiện tại. Xem hóa đơn.
- Tài khoản: Tìm kiếm (mã, họ tên, email). Thay đổi quyền truy cập, khóa tài khoản và xóa tài khoản. Thống kê số lượng tài khoản, số lượng quản trị viên, số lượng khách hàng, số lượng tài khoản đang hoạt động.
- Slider: Thêm, xóa, sửa và tìm kiếm (mã, tên). Thống kê theo số lượng slider.

### :bar_chart: Trang bán hàng
- Tìm kiếm sách theo tên.
- Xem sách mới nhất, bán chạy, xem gần đây, hàng đầu.
- Đăng ký tài khoản.
- Tài khoản khách hàng: Thêm, sửa, xóa giỏ hàng, tạo đơn hàng, thanh toán, xuất hóa đơn.

## :framed_picture:	Giao diện
- Trang bán hàng
<img src="/img/home.png" alt="Trang bán hàng" />
- Quản trị viên
<img src="/img/admin.png" alt="Trang bán hàng" />