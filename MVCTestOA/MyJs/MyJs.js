Date.prototype.format = function (format) {
    if (isNaN(this)) return '';
    var o = {
        'm+': this.getMonth() + 1,
        'd+': this.getDate(),
        'h+': this.getHours(),
        'n+': this.getMinutes(),
        's+': this.getSeconds(),
        'S': this.getMilliseconds(),
        'W': ["日", "一", "二", "三", "四", "五", "六"][this.getDay()],
        'q+': Math.floor((this.getMonth() + 3) / 3)
    };
    if (format.indexOf('am/pm') >= 0) {
        format = format.replace('am/pm', (o['h+'] >= 12) ? '下午' : '上午');
        if (o['h+'] >= 12) o['h+'] -= 12;
    }
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}

//window.onload = function () {
    
//        $.ajax({
//            type: "Get",
//            datatype: "Json",
//            url: "http://localhost:56362/api/adminsator/getall",
//            success: function (data) {
               
//                $.each(data, function (i, value) {
//                    var time = new Date(value.JoinTime).format('yyyy-mm-dd');
//                    $("#tab").append(
//                        " <tr><td><input type='checkbox' value='" + value.Id + "' name='chk'></td>" + "<td>" + value.Id + "</td><td><u style='cursor: pointer' onclick='member_show('张三', 'member-show.html', '10001', '360', '400')'>" + value.AdminName + "</u></td><td>" + value.Sex + "</td><td>"
//                        + value.Mobile + "</td><td>" + value.Email + "</td><td>" + time + "</td><td ><span class='layui - btn layui - btn - normal layui - btn - mini'>" + value.State + "</span></td>" +
//                                    "<td class='td-manage'><a style='text-decoration:none' onclick='member_stop(this,'10001')' href='javascript:;' title='停用'>"+
//                               "<i class='layui-icon'>&#xe601;</i></a>"+
//                        "<a title='编辑' id='edit' href='javascript:;'  class='ml-5' style='text-decoration:none'><i class='layui-icon'>&#xe642;</i></a>"+
//                            "<a style='text-decoration:none' onclick='member_password('修改密码','member-password.html','10001','600','400')' href='javascript:;' title='修改密码'> <i class='layui-icon'>&#xe631;</i></a>"+
//                        "<a title='删除' href='javascript:;' onclick='member_del(this,'" + value.Id + "')' style='text-decoration:none'><i class='layui-icon'>&#xe640;</i></a>"+
//                        "</td></tr>"
//                    )
//                });
//            }
//        });
   
//}

$(function () {
    $("#chkAll").click(function () {
        $("input[name='chk']").prop("checked", this.checked); 
    })
})




//批量删除提交
function delAll() {
    layer.confirm('确认要删除吗？', {
        btn: ['确定', '取消'], btn1: function () {
            //捉到所有被选中的，发异步进行删除
            var d = "";  //用来记录选中的复选框的value  ,value是ID
            $.each($('input:checkbox'), function () {
                if (this.checked) {
                    d += $(this).val() + "*";
                }
            });

            $.post("/MemberList/DeleteList", { "id": d }, function (data) {
                if (data == "OK") {
                    alert("删除成功");
                    location.reload();//刷新界面
                } else {
                    layer.msg('删除失败!', { icon: 1, time: 1000 });
                }
            })
        },
        btn2: function () {
            layer.close();
        }
    });
}
/*用户-添加*/
function member_add(title, url, w, h) {
    x_admin_show(title, url, w, h);
}
/*用户-查看*/
function member_show(title, url, id, w, h) {
    x_admin_show(title, url, w, h);
}

//利用webapi解决需要两个函数去控制它的状态的问题
function member_stop(obj, id) {
    layer.confirm('确认要停用吗？', function (index) {
        //发异步把用户状态进行更改

        $.ajax({
            type: "GET",
            datatype: "json",
            url: "http://localhost:56362/api/User/Update/" + id,
            success: function (data) {
                if (data == "已停用") {
                    layer.msg('已停用!', { icon: 5, time: 1000 });
                    $(obj).parents("tr").find(".td-status").html('<span class="layui-btn layui-btn-disabled layui-btn-mini">已停用</span>');


                } else {
                    layer.msg('已启用!', { icon: 6, time: 1000 });
                    $(obj).parents("tr").find(".td-status").html('<span class="layui-btn layui-btn-normal layui-btn-mini">已启用</span>');
                }
            }
        })
        


        //$(obj).parents("tr").find(".td-manage").prepend('<a style="text-decoration:none" onClick="member_start(this,id)" href="javascript:;" title="启用"><i class="layui-icon">&#xe62f;</i></a>');
        //$(obj).parents("tr").find(".td-status").html('<span class="layui-btn layui-btn-disabled layui-btn-mini">已停用</span>');
        //$(obj).remove();
        //layer.msg('已停用!', { icon: 5, time: 1000 });
    });
}

/*用户-启用*/
//function member_start(obj, id) {
//    layer.confirm('确认要启用吗？', function (index) {
//        //发异步把用户状态进行更改
//        $(obj).parents("tr").find(".td-manage").prepend('<a style="text-decoration:none" onClick="member_stop(this,id)" href="javascript:;" title="停用"><i class="layui-icon">&#xe601;</i></a>');
//        $(obj).parents("tr").find(".td-status").html('<span class="layui-btn layui-btn-normal layui-btn-mini">已启用</span>');
//        $(obj).remove();
//        layer.msg('已启用!', { icon: 6, time: 1000 });
//    });
//}
// 用户-编辑
function member_edit(title, url, id, w, h) {
    x_admin_show(title, url, w, h);
}
/*密码-修改*/
function member_password(title, url, id, w, h) {
    x_admin_show(title, url, w, h);
}
/*用户-删除*/
function member_del(obj, id) {
    layer.confirm('确认要删除吗？', {
        btn: ['确定', '取消'], btn1: function () {


            $.post("/MemberList/DeleteId", { "id": id }, function (data) {
                if (data == "OK") {
                    alert("删除成功");
                    location.reload();//刷新界面
                } else {
                    layer.msg('删除失败!', { icon: 1, time: 1000 });
                }
            })
        },
        btn2: function () {
            layer.close();
        }
    });
}


 

