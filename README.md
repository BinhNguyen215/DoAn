![UIT](https://img.shields.io/badge/from-UIT%20VNUHCM-blue?style=for-the-badge&link=https%3A%2F%2Fwww.uit.edu.vn%2F)
# GREEN PHARMACY

![Green   Blue Medical Center Logo (1)](https://github.com/BinhNguyen215/DoAn/assets/127644891/6a5d075a-4b89-49c7-8ac0-526e96557dd9)


## Table of contents
* [Giới thiệu chung](#Giới-thiệu-chung)
* [Các chức năng](#Các-chức-năng)
* [Framework và công nghệ](#Framework-và-công-nghệ)
* [Hướng dẫn setup](#Hướng-dẫn-setup)
## Giới thiệu chung
Tác giả: 
- Member: Nguyễn Sơn Bình - 22520135 - [Github](https://github.com/BinhNguyen215)
- Member: Nguyễn Nguyên Ngọc Anh - 22520135 - [Github](https://github.com/AndreNguyen03)
- Member: Hồ Phạm Phú An - 22520013 - [Github](https://github.com/FhuAnn)
- Member: Đặng Quốc Bảo - 22520098 - [Github](https://github.com/bdquoc)

Green Pharmacy là một ứng dụng quản lý nhà thuốc tiện ích, được xây dựng để mang lại trải nghiệm quản lý hiệu quả và hiện đại cho các doanh nghiệp trong lĩnh vực y tế. Với Green Pharmacy, việc quản lý hàng tồn kho trở nên đơn giản hơn bao giờ hết. Những tính năng như theo dõi số lượng và thông tin chi tiết sản phẩm, cùng với cảnh báo tồn kho thấp, giúp người dùng tránh được tình trạng thiếu hụt không mong muốn.

Green Pharmacy không chỉ là công cụ quản lý, mà còn là người bạn đồng hành đáng tin cậy trong việc xây dựng mối quan hệ với khách hàng. Tính năng quản lý thông tin khách hàng giúp lưu trữ thông tin cá nhân và lịch sử mua sắm của họ, trong khi chương trình khuyến mãi và ưu đãi đặc biệt tạo điều kiện thuận lợi cho khách hàng thân thiết. Đồng thời, với giao diện người dùng thân thiện, dễ sử dụng, Green Pharmacy là sự lựa chọn đáng tin cậy cho bất kỳ nhà thuốc nào mong muốn hiện đại hóa và tối ưu hóa hoạt động của mình.
## Các chức năng
1. Đăng nhập

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/66488e72-3a20-4546-972b-ff38835f6a3e)

2. Quên mật khẩu

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/7a16912e-c72f-4ace-a4dc-1254eef38868)

3. Đổi mật khẩu

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/8ecaa614-078f-4254-aaf7-0c0db00b14f9)

4. Phân tích doanh thu

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/6428e99f-5ffe-421b-b7a7-a829311fffa2)

5. Bán hàng

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/8ab53107-cc80-4a87-b173-7048d473055c)

6. Quản lý kho

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/3a09daca-5cf7-4e3c-afe2-5410d5d19b0c)

7. Quản lý nhân viên

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/f129d253-c014-47dd-8540-420488a4c8d0)

8. Quản lý nhà cung cấp

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/92c076ab-35fc-4198-a9a9-b8b82f645c1e)

9. Quản lý nhập kho

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/c46d1dd7-e0f6-4f26-9b97-fa99ece85411)

10. Quản lý xuất kho

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/354c6983-c4cd-4c73-a124-3c4a1211234f)

11. Quản lý hóa đơn

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/7b3fb8d7-5695-4f7b-8a63-7f4f8114c160)

12. Quản lý phiếu lương

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/1e0fe3bf-463c-489e-99e2-b4365e6750a8)

13. Đăng xuất

![image](https://github.com/BinhNguyen215/DoAn/assets/127644891/c35c3a52-6cad-4cf0-85ca-59f4dbd3342a)


## Framework và công nghệ
1. Công nghệ:

Đồ án sử dụng ngôn ngữ C# kết hợp nền tảng WinForm và quản lý cơ sở dữ liệu trên SQL Server Management Studio (SSMS)

2. Framework:

Một số framwork mà đồ án sử dụng:
* Framework Bunifu UI
* Framework RJCodeAdvance

## Hướng dẫn setup
Đăng kí Bunifu UI Framework
username: supernguyen2000@gmail.com
key: deb1d35d238d6d6907fefa706c8fa1b4

Khi clone code về, vào App.config sửa connectionstring thành đường dẫn của máy local và attach MedicineDB.mdf vào SSMS (run as administrator).

Khi download gói file setup.rar về -> chạy file setup.exe -> hiện hộp thoại chọn địa chỉ lưu file set up dữ liệu -> chọn next -> next -> close. Vào địa chỉ vừa chọn -> cấp quyền cho hai file MedicineDB.mdf và MedicineDB.log như sau:

B1: Chuột phải vào biểu tượng chọn. Properties, chọn mục Security 

B2: Click vào từng dòng một, chọn Edit, Click chọn tất cả option

B3: Lặp lại thực hiện bước 2 cho tới khi không còn dòng nào 

B4: Ấn ok

Vấn đề chưa giải quyết được: Đã xuất ra fiel setup nhưng do lỗi phiên bản sql tại máy người dùng khác máy remote.
