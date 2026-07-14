let createFormButton: HTMLButtonElement | null;
let titleInput: string;
let authorInput: string;
let messageInput: string;

window.addEventListener('load', function() {
    createFormButton = document.getElementById("submit-button") as HTMLButtonElement;
    createFormButton?.addEventListener('click', async () => {
        titleInput = (document.getElementById("input-title") as HTMLTextAreaElement)?.value;
        authorInput = (document.getElementById("input-author") as HTMLTextAreaElement)?.value;
        messageInput = (document.getElementById("input-message") as HTMLTextAreaElement)?.value;
        await postThread(titleInput, authorInput, messageInput); 
        window.location.href = baseurl + 'html/explore.html'
    });
});
