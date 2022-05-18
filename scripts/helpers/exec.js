const { spawn } = require("child_process");
const { log, error } = console;

module.exports = async (cmd, args) =>
	await new Promise((resolve, reject) => {
		try {
			cmd = cmd
				.replaceAll(/(\r\n|\n|\r)/gm, "") //remove new lines
				.replaceAll(/\s+/g, " "); //remove extra spaces

			log(`${cmd} ${args.join(" ")}`);
			const process = spawn(cmd, args);

			process.stdout.on("data", (data) => log(data.toString()));

			process.on("error", reject);

			process.on("close", (code) => {
				resolve(code);
			});
		} catch (err) {
			reject(err);
		}
	});
