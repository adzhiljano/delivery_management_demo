var spawn = require('child_process').spawn;
process.chdir('../DeliveryManagement.Database');
ls    = spawn('cmd.exe', ['/c', `CreateAll.bat`]);

ls.stdout.on('data', function (data) {
console.log('stdout: ' + data);
});

ls.stderr.on('data', function (data) {
console.log('stderr: ' + data);
});

ls.on('exit', function (code) {
console.log('child process exited with code ' + code);
});