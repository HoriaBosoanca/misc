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
var baseurl = 'http://localhost:8010/';
// POST Thread
function postThread(title, author, message) {
    return __awaiter(this, void 0, void 0, function* () {
        if (title && author && message) {
            try {
                const res = yield fetch(baseurl + 'thread', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        title: title,
                        author: author,
                        message: message
                    })
                });
                if (!res.ok) {
                    throw new Error('Res not ok!');
                }
            }
            catch (err) {
                console.error(err);
            }
        }
        else {
            console.error("request made with undefined params");
        }
    });
}
// GET Thread[]
function getAllThreads() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const res = yield fetch(baseurl + 'thread', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (!res.ok) {
                throw new Error('Res not ok!');
            }
            const data = yield res.json();
            return data;
        }
        catch (err) {
            console.log(err);
            return undefined;
        }
    });
}
// GET Thread
function getThread(threadId) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const res = yield fetch(baseurl + 'thread/' + threadId, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (!res.ok) {
                throw new Error('Res is not ok!');
            }
            const data = yield res.json();
            return data;
        }
        catch (err) {
            console.error(err);
            return undefined;
        }
    });
}
// POST Comment
function postComment(threadId, commentContent) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const res = yield fetch(baseurl + 'thread/comment/' + threadId, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    content: commentContent
                })
            });
            if (!res.ok) {
                throw new Error(`Failed to post comment. Status: ${res.status} ${res.statusText}`);
            }
        }
        catch (err) {
            console.error(err);
        }
    });
}
// GET Comment -> threadId
function getComment(threadId) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const res = yield fetch(baseurl + 'thread/comment/getbythreadid/' + threadId, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            const data = yield res.json();
            return data;
        }
        catch (err) {
            console.error(err);
        }
    });
}
