﻿var table;
var datatable;
var updatedRow;
var exportedCols = [];

//DataTables
var headers = $("th");
$.each(headers, function (i) {
  if (!$(this).hasClass("js-no-export")) exportedCols.push(i);
});

// Class definition
var KTDatatables = (function () {
  // Private functions
  var initDatatable = function () {
    // Init datatable --- more info on datatables: https://datatables.net/manual/
    datatable = $(table).DataTable({
      info: false,
      pageLength: 10,
    });
  };

  // Hook export buttons
  var exportButtons = () => {
    const documentTitle = $(".js-datatables").data("document-title");
    var buttons = new $.fn.dataTable.Buttons(table, {
      buttons: [
        {
          extend: "copyHtml5",
          title: documentTitle,
          exportOptions: {
            columns: exportedCols,
          },
        },
        {
          extend: "excelHtml5",
          title: documentTitle,
          exportOptions: {
            columns: exportedCols,
          },
        },
        {
          extend: "csvHtml5",
          title: documentTitle,
          exportOptions: {
            columns: exportedCols,
          },
        },
        {
          extend: "pdfHtml5",
          title: documentTitle,
          exportOptions: {
            columns: exportedCols,
          },
        },
      ],
    })
      .container()
      .appendTo($("#kt_datatable_example_buttons"));

    // Hook dropdown menu click event to datatable export buttons
    const exportButtons = document.querySelectorAll(
      "#kt_datatable_example_export_menu [data-kt-export]"
    );
    exportButtons.forEach((exportButton) => {
      exportButton.addEventListener("click", (e) => {
        e.preventDefault();

        // Get clicked export value
        const exportValue = e.target.getAttribute("data-kt-export");
        const target = document.querySelector(
          ".dt-buttons .buttons-" + exportValue
        );

        // Trigger click event on hidden datatable export buttons
        target.click();
      });
    });
  };

  // Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
  var handleSearchDatatable = () => {
    const filterSearch = document.querySelector('[data-kt-filter="search"]');
    filterSearch.addEventListener("keyup", function (e) {
      datatable.search(e.target.value).draw();
    });
  };

  // Public methods
  return {
    init: function () {
      table = document.querySelector(".js-datatables");

      if (!table) {
        return;
      }

      initDatatable();
      exportButtons();
      handleSearchDatatable();
    },
  };
})();

$(document).ready(function () {
  //SweetAlert
  var message = $("#Message").text();
  if (message !== "") {
    showSuccessMessage(message);
  }

  //Handle bootstrap modal
  $("body").delegate(".js-render-modal", "click", function () {
    var btn = $(this);
    var modal = $("#Modal");

    modal.find("#ModalLabel").text(btn.data("title"));

    if (btn.data("update") !== undefined) {
      updatedRow = btn.parents("tr");
    }

    $.get({
      url: btn.data("url"),
      success: function (form) {
        modal.find(".modal-body").html(form);
        $.validator.unobtrusive.parse(modal);
      },
      error: function () {
        showErrorMessage();
      },
    });

    modal.modal("show");
  });
});
