$(document).ready(function () {
    const api = "http://localhost:49814/api/Values";

    $("#btnReset").on("click", function () {
        window.location.reload();
    })

    $("#btnAdd").on("click", function () {
        var val = parseInt($("#txtCashFlow").val());
        if (val <= 0) {
            showMessage("Please enter a valid Cash Flow.");
            return;
        }

        var tbody = $("#tblCashFlows").find("tbody");
        tbody.append(`<tr><td>${val}</td><td><button type="button" class="btn btn-danger">Delete</button></td></tr>`);

        var btn = tbody.find(".btn-danger")
        btn.bind("click", function () {
            $(this).closest("tr").remove();
        })

        $("#txtCashFlow").val("0");
    })

    $("#btnCalculate").on("click", function () {
        if (!validateForm()) {
            return;
        }

        $("#chart").hide();
        calculateNPV();
    })

    function showMessage(message) {
        $('#myModal').find(".modal-body").text(message)
        $('#myModal').modal('show');
    }

    function validateForm() {
        var investment = parseFloat($("#IntialInvestment").val());
        if (investment <= 0) {
            showMessage("Please enter a valid Initial Investment.");
            return false;
        }

        var trs = $("#tblCashFlows").find("tbody>tr");
        if (trs.length === 0) {
            showMessage("Please enter a Cash Flows.");
            return false;
        }

        var lowerBound = parseFloat($("#LowerBoundDiscountRate").val());
        if (lowerBound <= 0) {
            showMessage("Please enter a valid Lower Bound Discount Rate.");
            return false;
        }

        var upperBound = parseFloat($("#UpperBoundDiscountRate").val());
        if (upperBound <= 0) {
            showMessage("Please enter a valid Upper Bound Discount Rate.");
            return false;
        }

        var incrementRate = parseFloat($("#DiscountRateIncrement").val());
        if (incrementRate <= 0) {
            showMessage("Please enter a valid Discount Rate Increment.");
            return false;
        }

        return true;
    }

    function setCashFlows() {
        var trs = $("#tblCashFlows").find("tbody>tr");
        var cashFlows = [];
        $.each(trs, function (index, tr) {
            var value = $(tr).children("td:first").text();
            cashFlows.push(parseInt(value));
        });
        $("#CashFlows").val(cashFlows);
    }

    function calculateNPV() {
        setCashFlows();
        $.ajax({
            url: api,
            type: "POST",
            data: $("form").serialize(),
            success: function (result) {
                $("#chart").show();
                drawChart(result);
            }
        });
    }

    function drawChart(result) {
        new Chart(document.getElementById("chart"), {
            type: 'line',
            data: {
                labels: result.Labels,
                datasets: [
                    {
                        label: "NPV",
                        data: result.Values
                    }
                ]
            },
            options: {
                legend: { display: false },
                title: {
                    display: true,
                    text: 'NPV Calculations per Discount Rate'
                }
            }
        });
    }
})