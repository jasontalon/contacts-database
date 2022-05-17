const {exec} = require("child_process")

const executeDbCommand = (command) =>
    new Promise((resolve, reject) => {
        const psql = `docker exec contacts-database-db-1 bash -c "psql -U postgres --no-password -c \\"${command}\\""`

        exec(psql, (err, stdOut, stdErr) => {
            if (!!err)
                reject(stdErr)
            else
                resolve(stdOut)
        })
    })

module.exports = async (args) => {
    const {exit} = process
    const commandArgs = ["--command", "-c"]

    if (!args.some(arg => commandArgs.some(cmd => arg.startsWith(cmd)))) {
        console.error(`Expects ${commandArgs.join(' or ')} argument`)
        exit(1)
        return
    }

    const arg = args.find(arg => commandArgs.some(cmd => arg.startsWith(cmd)))
        , commandArg = commandArgs.find(cmd => arg.startsWith((cmd)))

    if (arg.replaceAll(commandArg, '').startsWith('=')) {
        const stripCmdArg = arg.replaceAll(commandArg, '').replace('=', '')
        return await executeDbCommand(stripCmdArg)
    } else if (args.length === 4) {
        console.error(`command db expects value for of ${commandArgs.join(' or ')}`)
        exit(1)
        return
    } else {
        return await executeDbCommand(args[4])
    }
}