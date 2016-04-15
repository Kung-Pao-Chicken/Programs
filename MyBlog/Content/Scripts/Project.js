$(document).ready(function () {
    var option;
    var catid;
    var catname;
    $(".inputdialogback").hide();

    $(".option,#add").click(function () {
        var sender = $(this);
        option = sender.attr("id");
        catid = sender.parents('.listitem').attr('tag');
        catname = sender.parents('.listitem').children(".catname").text();

        if (option == "delete") {
            $.post("/MyAdmin/ProjectPost", { "option": "delete", "catid": catid }, function (data, status) {
                sender.parents('.listitem').remove();
                alert("状态：" + data);
            });
        } else if (option == "add") {
            $(".inputdialogback").show();
            $(".okbutton").click(function () {
                catname = $(".catnametext").val();
                $(".inputdialogback").hide();
                $.post("/MyAdmin/ProjectPost", { "option": "add", "catname": catname }, function (data, status) {
                    alert("状态：" + data);
                    //sender.parents('form').append("<tr class='listitem' tag='" + str[1] + "'><td class='listitemtitle'>" + catname + "</td><td class='listitemcatid'>" + catid + "</td><td class='listitemoption'><a class='option' id='update' href='#'>修改</a><a class='option' id='delete' href='#'>删除</a></td></tr>");
                    location.reload();
                });
            });
        } else if (option == "update") {
            $(".catnametext").val(catname);
            $(".inputdialogback").show();
            $(".okbutton").click(function () {
                catname = $(".catnametext").val();
                $(".inputdialogback").hide();
                $.post("/MyAdmin/ProjectPost", { "option": "update", "catid": catid, "catname": catname }, function (data, status) {
                    alert("状态：" + data);
                    //sender.parents(".listitem").children(".listitemtitle").text(catname);
                    location.reload();
                });
            });
        }
        $(".cancelbutton").click(function () {
            $(".inputdialogback").hide();
            $(".okbutton").unbind("click");
        });
    });
});