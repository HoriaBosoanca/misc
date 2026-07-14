let threads: HTMLElement | null;
let allThreadsData: Thread[] | undefined;

window.addEventListener('load', async function() {
    
    threads = document.getElementById("threads-box");
    allThreadsData = await getAllThreads();
    if(allThreadsData){
        for(let i = 0; i < allThreadsData.length; i++){
            displayThread(allThreadsData[i].title, allThreadsData[i].id);
        }
    }
    else{
        console.error("allThreadsData is undefined")
    }
});

function displayThread(threadName: string, threadId: number): void{
    let thread: HTMLButtonElement = document.createElement('button');
    thread.className = 'col-12 rounded mt-5 btn btn-danger'; // css

    let threadTitle: HTMLHeadElement = document.createElement('h2');
    threadTitle.className = 'fw-bold text-white'; // css
    thread.appendChild(threadTitle);
    threadTitle.innerHTML = threadName;

    threads?.appendChild(thread);

    // go to read page
    thread.addEventListener('click', () => {
        window.location.href = baseurl + 'html/read.html' + '?threadId=' + threadId;
    });
}
