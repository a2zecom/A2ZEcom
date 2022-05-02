$('#form-submit').click(function () {
    let obj = {}
    obj.name = $('#name').val();
    obj.email = $('#email').val();
    obj.message = $('#message').val();
    obj.mobile = $('#number').val();
    console.log(obj);
    $.ajax({
        type: 'POST',
        url: 'Home/SendEmail',
        dataType: 'json',
        data: { 'message': obj.message, 'name': obj.name, 'mobile': obj.mobile, 'email': obj.email },
        success: function (data) {
            resetForm();
            console.log('done');
          
        },
        error: function (ex) {
            console.log(ex)
            
        }
    });


})

function resetForm() {
    $('#name').val('');

 $('#email').val('');
  $('#message').val('');
   $('#number').val('');
}