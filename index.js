const path = require("path"), {argv, exit} = process, {readdir} = require("fs/promises"), {
    log,
    error
} = console, {argsparse} = require("./scripts/helpers");

(async () => {
    const cmdPath = path.join(__dirname, "scripts", "commands"), files = await readdir(cmdPath),
        validCommands = files.map((file) => file.replace(".js", ""));

    if (argv.length <= 2) {
        error("Expects at least a command");
        log(`valid commands:\n${validCommands.join("\n")}`);
        exit(1);
        return;
    }

    const command = argv[2];

    if (!validCommands.includes(command)) {
        error(`Expects valid commands: ${validCommands.join(", ")}`);
        exit(1);
        return;
    }

    try {
        const {
            args: cmdArgs, exec,
        } = require(`./scripts/commands/${command}`);

        if (argv.includes("-h") || argv.includes("--help")) {
            log("listed below are available arguments for " + command);
            log(cmdArgs);
            exit();
            return;
        }

        const [args, err] = argsparse(argv, cmdArgs);

        if (!!err) {
            error(err);
            exit(1);
            return;
        }

        await exec(args);
    } catch (err) {
        error(err);
        exit(1);
    }
})();
