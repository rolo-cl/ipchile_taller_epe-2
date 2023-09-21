echo "*******************************************************"
echo "update repository"
echo "*******************************************************"
git config user.name "rduarte"
git config user.email "rduarte@ldstudios.cl"
git config pull.rebase false
echo "*******************************************************"
echo "commit and push to git repository"
echo "*******************************************************"
git add . && git commit -m "Ajustes -> $(date)" && git push
