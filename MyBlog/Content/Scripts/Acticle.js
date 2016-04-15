$(document).ready(function () {
    $("#save").click(function () {
        if (UM.getEditor('myEditor').hasContents() == true) {
            var acticleid = $("#acticleid").text();
            $.post("/MyAdmin/ActiclePost/", { "option": "save", "contain": escape(UM.getEditor('myEditor').getContent()), "acticleid": acticleid, "abstract": UM.getEditor('myEditor').getContentTxt().substr(0, 600) }, function (data) {
                alert(data);
            });
        }
    });
});