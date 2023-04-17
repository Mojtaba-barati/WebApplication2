$(document).ready(function () {
    
    $.post("/admin/product/GetAll").done(function (res) {

        var a = 1;
        
        for (var item in res) {
            
            
            $("#tbl_visits").append(
                "<tr id='tr_" + res[item].id + "'>" +
                "<td 	width='20%'>" + a + "</td>" +
                "<td 	width='20%'>" + res[item].title + "</td>" +
                "<td	width='20%'>" + res[item].another + "</td>" +
                "<td 	width='20%'>" + res[item].listprice + "</td>" +
                "<td 	width='20%'>" + res[item].category.name + "</td>" +
                "<td 	><div class='btn btn-info p-xl-0'><a href='/admin/product/upsert?id=" + res[item].id + "'><span class='btn text-white'><i class='bi bi-pen-fill'>" + "ویرایش" + "</i></span></a></div></td>" +
                "<td 	><div class='btn btn-danger p-xl-0 rv'><a id='s'><span class='btn text-white'><i class='bi bi-trash'>" + "حذف" + "</i></span></a></div></td>" +
                "<tr>"
                
            );
            a++;           
        }
    }).fail(function () { }).always(function () { });


});


$("table").on('click', '.rv', function () {
   
    var trid = "#" + $(this).closest('tr').attr("id");
    var state = trid.split("_");
    
    Swal.fire({
        title: 'آیا مطمئن هستید؟',
        text: "اگر موافق هستید روی حذف کلیک کنید",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'حذف'
    }).then((result) => {
        if (result.isConfirmed) {

            $.post('/admin/product/Delete', { Id: state[1] }).done(function (res) {
                if (res) {
   
                    swal.fire("نوبت حذف شد", {
                        icon: "Success",
                    });
                    $(trid).remove(); 
                }                
            }).fail(function () { }).always(function () { });

        };
    });
});