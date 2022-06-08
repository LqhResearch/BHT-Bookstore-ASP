using System;

namespace WebForm
{
    public static class Content
    {
        /// <summary>
        /// Properties
        /// </summary>
        public static int RECORD_NUMBER_FOR_PAGE = 10;

        /// <summary>
        /// HTML frontend
        /// </summary>
        public static string SuccessMsg = "<div class='alert alert-success'><strong>Thông báo!</strong> Thành công</div>";
        public static string ErrorMsg = "<div class='alert alert-danger'><strong>Thông báo!</strong> Thất bại</div>";
        public static string RepeaterNoData = "<tr class='text-center'><td colspan='100%'><i>Không tìm thấy dữ liệu</i></td></tr>";
    }
}