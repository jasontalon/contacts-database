const {exec} = require("child_process")

const executeDbCommand = (command) => {
    const psql = `docker exec contacts-database-db-1 bash -c "psql -U postgres --no-password -c \\"${command}\\""`

    exec(psql, (err, stdOut, strErr) => {
        if (!!err) {
            console.error(strErr)
            process.exit(1)
            return
        }
        console.log(stdOut)
    })
}

module.exports = async (args) => {
    const commandArgs = ["--command", "-c"]

    if (!args.some(arg => commandArgs.some(cmd => arg.startsWith(cmd)))) {
        console.error(`Expects ${commandArgs.join(' or ')} argument`)
        process.exit(1)
        return
    }

    const arg = args.find(arg => commandArgs.some(cmd => arg.startsWith(cmd)))
        , commandArg = commandArgs.find(cmd => arg.startsWith((cmd)))

    if (arg.replaceAll(commandArg, '').startsWith('=')) {
        const stripCmdArg = arg.replaceAll(commandArg, '').replace('=', '')
        executeDbCommand(stripCmdArg)
    } else if (args.length === 4) {
        console.error(`command db expects value for of ${commandArgs.join(' or ')}`)
        process.exit(1)
        return
    } else {
        executeDbCommand(args[4])
    }
}