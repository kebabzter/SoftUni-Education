function solve(obj) {
    let method = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriRegex = /(^[\w.]+$)/gm;
    let version = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let messageRegex = /[<>&'"\\]/gm;

    if (!obj.hasOwnProperty('method') || !method.includes(obj.method)) {
        throw new Error('Invalid request header: Invalid Method')
    }

    if (!obj.hasOwnProperty('uri') || !uriRegex.test(obj.uri)) {
        throw new Error('Invalid request header: Invalid URI')
    }

    if (!obj.hasOwnProperty('version') || !version.includes(obj.version)) {
        throw new Error('Invalid request header: Invalid Version')
    }

    if (!obj.hasOwnProperty('message') || messageRegex.test(obj.message)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return obj;
}