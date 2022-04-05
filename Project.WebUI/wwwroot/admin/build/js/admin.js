
function deleteRecord(recordName,deleteAction,deleteID) {
    $('#deleteRecordModal .modal-body').text(recordName + ' isimli kaydı silmek istediğinizden emin misiniz?');
    $('#deleteRecordModal #yesButton').attr("href", deleteAction+"/delete/" + deleteID);
    $('#deleteRecordModal').modal('show')
}