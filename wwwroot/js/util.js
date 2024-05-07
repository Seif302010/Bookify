$(document).ready(function () {
  KTUtil.onDOMContentLoaded(function () {
    KTDatatables.init();
  });
  $(".js-delete-element").on("click", function () {
    var btn = $(this);
    bootbox.confirm({
      message: "Are you sure about that",
      buttons: {
        confirm: {
          label: "Yes",
          className: "btn-danger",
        },
        cancel: {
          label: "No",
          className: "btn-secondary",
        },
      },
      callback: function (result) {
        if (result) {
          $.post({
            url: "/" + pageTitle + "/Delete/" + btn.data("id"),
            data: {
              __RequestVerificationToken: $(
                'input[name="__RequestVerificationToken"]'
              ).val(),
            },
            success: function () {
              btn.parents("tr").remove();
              if ($(".js-datatables tbody tr").length === 0) {
                $(".table-responsive").remove();
                $(".card-body").html("<h1>No " + pageTitle + " to show</h1>");
              }
            },
          });
        }
      },
    });
  });
});
