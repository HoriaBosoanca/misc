window.addEventListener('load', async () => {
    let threadData: Thread | undefined = await getThreadData();
    if(threadData){
        setTitle(threadData);
        setAuthor(threadData);
        setMessage(threadData);
        await setComments(threadData);
    }
    else{
        console.error("there was no thread data returned")
    }

    let textareaElement: HTMLTextAreaElement = document.getElementById('comment-textarea') as HTMLTextAreaElement;
    textareaElement?.addEventListener('keydown', async (e: KeyboardEvent) => {
        if(e.key == 'Enter'){
            // don't send empty comments or comments that begin with newline to Database
            if(textareaElement?.value != '' && textareaElement?.value.substring(0, 1) != '\n' && threadData){
                await postComment(threadData.id, textareaElement.value);
                displayComment(textareaElement.value);
                textareaElement.value = '';
            }
        }
    })
});

async function getThreadData(): Promise<Thread | undefined> {
    let threadId: string | null = new URLSearchParams(window.location.search).get('threadId');
    if(threadId){
        let threadIdNum: number = parseInt(threadId, 10);
        return await getThread(threadIdNum);
    }
    else{
        console.error("no url search param")
    }
}

function setTitle(data: Thread): void {
    let titleElement: HTMLElement | null = document.getElementById('thread-title');
    if(titleElement){
        titleElement.innerHTML = data.title;    
    }
    else{
        console.log("undefined param")
    }
}

function setAuthor(data: Thread): void{
    let authorElement: HTMLElement | null = document.getElementById('read-author');
    if(authorElement){
        authorElement.innerHTML = 'By: ' + data.author;
    }
    else{
        console.log("undefined param")
    }
}

function setMessage(data: Thread): void {
    let messageElement: HTMLElement | null = document.getElementById('read-message');
    if(messageElement){
        messageElement.innerHTML = data.message;
    }
    else{
        console.log("undefined param")
    }
}

async function setComments(data: Thread): Promise<void> {
    let commentData: Comment[] = await getComment(data.id);
    commentData.forEach(comment => {
        displayComment(comment.content);
    });
}

function displayComment(content: string){
    let commentParentElement: HTMLElement | null = document.getElementById('comment-box');
    let commentDiv: HTMLElement = document.createElement('div');
    commentDiv.className = 'bg-danger mt-3 rounded mx-5'; // css

    let commentParagraph: HTMLElement = document.createElement('p');
    commentParagraph.className = 'text-white fs-3 fw-bold px-3'; // css
    commentParagraph.innerHTML = content;
    commentDiv.appendChild(commentParagraph);

    commentParentElement?.appendChild(commentDiv);
}
