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
window.addEventListener('load', () => __awaiter(void 0, void 0, void 0, function* () {
    let threadData = yield getThreadData();
    if (threadData) {
        setTitle(threadData);
        setAuthor(threadData);
        setMessage(threadData);
        yield setComments(threadData);
    }
    else {
        console.error("there was no thread data returned");
    }
    let textareaElement = document.getElementById('comment-textarea');
    textareaElement === null || textareaElement === void 0 ? void 0 : textareaElement.addEventListener('keydown', (e) => __awaiter(void 0, void 0, void 0, function* () {
        if (e.key == 'Enter') {
            // don't send empty comments or comments that begin with newline to Database
            if ((textareaElement === null || textareaElement === void 0 ? void 0 : textareaElement.value) != '' && (textareaElement === null || textareaElement === void 0 ? void 0 : textareaElement.value.substring(0, 1)) != '\n' && threadData) {
                yield postComment(threadData.id, textareaElement.value);
                displayComment(textareaElement.value);
                textareaElement.value = '';
            }
        }
    }));
}));
function getThreadData() {
    return __awaiter(this, void 0, void 0, function* () {
        let threadId = new URLSearchParams(window.location.search).get('threadId');
        if (threadId) {
            let threadIdNum = parseInt(threadId, 10);
            return yield getThread(threadIdNum);
        }
        else {
            console.error("no url search param");
        }
    });
}
function setTitle(data) {
    let titleElement = document.getElementById('thread-title');
    if (titleElement) {
        titleElement.innerHTML = data.title;
    }
    else {
        console.log("undefined param");
    }
}
function setAuthor(data) {
    let authorElement = document.getElementById('read-author');
    if (authorElement) {
        authorElement.innerHTML = 'By: ' + data.author;
    }
    else {
        console.log("undefined param");
    }
}
function setMessage(data) {
    let messageElement = document.getElementById('read-message');
    if (messageElement) {
        messageElement.innerHTML = data.message;
    }
    else {
        console.log("undefined param");
    }
}
function setComments(data) {
    return __awaiter(this, void 0, void 0, function* () {
        let commentData = yield getComment(data.id);
        commentData.forEach(comment => {
            displayComment(comment.content);
        });
    });
}
function displayComment(content) {
    let commentParentElement = document.getElementById('comment-box');
    let commentDiv = document.createElement('div');
    commentDiv.className = 'bg-danger mt-3 rounded mx-5'; // css
    let commentParagraph = document.createElement('p');
    commentParagraph.className = 'text-white fs-3 fw-bold px-3'; // css
    commentParagraph.innerHTML = content;
    commentDiv.appendChild(commentParagraph);
    commentParentElement === null || commentParentElement === void 0 ? void 0 : commentParentElement.appendChild(commentDiv);
}
