const minimist = require("./minimist");

module.exports = (argv, cmdArgs) => {
	cmdArgs = cmdArgs
		.flat()
		.filter((arg) => arg.startsWith("-"))
		.map((arg) => arg.replaceAll("-", ""));

	const { _, ...args } = minimist(argv.slice(2)),
		_args = Object.keys(args),
		invalidArgs = _args.filter((arg) => !cmdArgs.includes(arg));

	if ((invalidArgs?.length ?? 0) > 0)
		return [null, `invalid argument ${invalidArgs.join(", ")}`];

	return [args, null];
};
