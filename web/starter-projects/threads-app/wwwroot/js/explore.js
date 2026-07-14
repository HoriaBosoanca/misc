"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
let threads;
let allThreadsData;
window.addEventListener('load', function () {
    return __awaiter(this, void 0, void 0, function* () {
        threads = document.getElementById("threads-box");
        allThreadsData = yield getAllThreads();
        if (allThreadsData) {
            for (let i = 0; i < allThreadsData.length; i++) {
                displayThread(allThreadsData[i].title, allThreadsData[i].id);
            }
        }
        else {
            console.error("allThreadsData is undefined");
        }
    });
});
function displayThread(threadName, threadId) {
    let thread = document.createElement('button');
    thread.className = 'col-12 rounded mt-5 btn btn-danger'; // css
    let threadTitle = document.createElement('h2');
    threadTitle.className = 'fw-bold text-white'; // css
    thread.appendChild(threadTitle);
    threadTitle.innerHTML = threadName;
    threads === null || threads === void 0 ? void 0 : threads.appendChild(thread);
    // go to read page
    thread.addEventListener('click', () => {
        window.location.href = baseurl + 'html/read.html' + '?threadId=' + threadId;
    });
}
