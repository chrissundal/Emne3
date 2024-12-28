function goToLogin()
{
    Model.app.currentPage = Model.currentPages[0];
    updateView();
}