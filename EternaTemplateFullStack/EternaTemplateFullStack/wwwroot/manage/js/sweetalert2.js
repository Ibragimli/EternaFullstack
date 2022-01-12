$(function () {
    $(document).on("click", ".deleteBtn", function (e) {
        e.preventDefault();
        let dataId = $(this).attr("data-id")
        alert(dataId)
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(`/manage/service/Delete/${dataId}`)
                    .then(response =>  {
                        if (response.ok) {
                            window.location.reload();
                        }
                        else {
                            alert("Silmek mumkun olmadi!")
                        }
                    })
            }
        })
    })
})